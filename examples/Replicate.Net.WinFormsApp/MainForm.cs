using System.Drawing.Drawing2D;
using Replicate.Net.Client;
using Replicate.Net.Factory;
using Replicate.Net.Models;

namespace Replicate.Net.WinFormsApp
{
	public partial class MainForm : Form
	{
		private Prediction? _prediction;

		private PictureBox[] _pictureBoxes => Controls.OfType<PictureBox>().ToArray();

		public MainForm()
		{
			InitializeComponent();
		}

		private async void btnGenerate_Click(object sender, EventArgs e)
		{
			await ExecuteAsync(async () =>
			{
				SetLoading();

				var factory = new InPainterApiFactory();
				var api = factory.GetApi();

				var input = new PredictionInput
				{
					Prompt = txtPrompt.Text
				};

				_prediction = await api.CreatePredictionAndWaitOnResultAsync(input);

				if (_prediction is not null && _prediction.GeneratedPictures is not null)
				{
					picture1.ImageLocation = _prediction.GeneratedPictures[0];
					picture2.ImageLocation = _prediction.GeneratedPictures[1];
					picture3.ImageLocation = _prediction.GeneratedPictures[2];
					picture4.ImageLocation = _prediction.GeneratedPictures[3];
				}

				Refresh();
			});
		}

		private void txtPrompt_TextChanged(object sender, EventArgs e)
		{
			var textBox = (TextBox)sender;
			btnGenerate.Enabled = !string.IsNullOrEmpty(textBox.Text);
		}

		/// <summary>
		/// https://stackoverflow.com/a/20725791/255966
		/// </summary>
		private void picture_MouseDown(object sender, MouseEventArgs e)
		{
			var pictureBox = (PictureBox)sender;

			if (string.IsNullOrEmpty(pictureBox.ImageLocation))
			{
				return;
			}

			switch (e.Button)
			{
				case MouseButtons.Right:
					rightClickMenuStrip.Show(pictureBox, new Point(e.X, e.Y));
					break;
			}
		}

		private void rightClickMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			var menu = (ContextMenuStrip)sender;

			var pictureBox = menu.SourceControl as PictureBox;
			if (pictureBox is null)
			{
				return;
			}

			switch (e.ClickedItem.Text)
			{
				case "Save":
					ShowSaveFileDialog(pictureBox);
					break;
			}
		}

		private void ShowSaveFileDialog(PictureBox pictureBox)
		{
			var (imageFilename, promptFileName) = BuildFileNames(pictureBox);
			var saveFileDialog = new SaveFileDialog
			{
				Filter = @"PNG|*.png",
				FileName = imageFilename
			};

			var result = saveFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				Execute(() =>
				{
					pictureBox.Image.Save(saveFileDialog.FileName);
					File.WriteAllText(Path.Combine(Path.GetDirectoryName(saveFileDialog.FileName)!, promptFileName), _prediction!.Input.Prompt);
				});
			}
		}

		private (string ImageFileName, string PromptFileName) BuildFileNames(PictureBox pictureBox)
		{
			return ($"{_prediction!.Id}_{Path.GetFileName(pictureBox.ImageLocation)}", $"{_prediction!.Id}_Prompt.txt");
		}

		private void ShowFolderBrowserDialog()
		{
			var folderBrowserDialog = new FolderBrowserDialog();
			var result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				Execute(() =>
				{
					foreach (var pictureBox in _pictureBoxes)
					{
						var (imageFilename, promptFileName) = BuildFileNames(pictureBox);

						pictureBox.Image.Save(Path.Combine(folderBrowserDialog.SelectedPath, imageFilename));
						File.WriteAllText(Path.Combine(folderBrowserDialog.SelectedPath, promptFileName), _prediction!.Input.Prompt);
					}
				});
			}
		}

		private void buttonSaveAll_Click(object sender, EventArgs e)
		{
			ShowFolderBrowserDialog();
		}

		private void SetLoading()
		{
			foreach (var pictureBox in _pictureBoxes)
			{
				pictureBox.Image = Resources.Loading;
			}
		}

		private void ToggleButtons(bool show)
		{
			btnGenerate.Enabled = show;
			buttonSaveAll.Enabled = show;
			txtPrompt.Enabled = show;
		}

		private void Execute(Action action)
		{
			try
			{
				ToggleButtons(false);
				action();
			}
			finally
			{
				ToggleButtons(true);
			}
		}

		private async Task ExecuteAsync(Func<Task> action)
		{
			try
			{
				ToggleButtons(false);
				await action();
			}
			finally
			{
				ToggleButtons(true);
			}
		}
	}
}