using Replicate.Net.Client;
using Replicate.Net.Models;
using Replicate.Net.WinFormsApp.InPainter.Client;
using Replicate.Net.WinFormsApp.InPainter.Factory;

namespace Replicate.Net.WinFormsApp;

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
		await ExecuteAsync
			(async () =>
			{
				SetImage(Resources.Loading);

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
				else
				{
					SetImage(Resources.Error);
				}
			},
			() => SetImage(Resources.Error)
		);
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

	private string BuildImageFileName(PictureBox pictureBox)
	{
		return $"{_prediction!.Id}_{Path.GetFileName(pictureBox.ImageLocation)}";
	}

	private string BuildPromptFileName()
	{
		return $"{_prediction!.Id}_Prompt.txt";
	}

	private void ShowSaveFileDialog(PictureBox pictureBox)
	{
		var imageFilename = BuildImageFileName(pictureBox);
		var promptFileName = BuildPromptFileName();
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
					var imageFilename = BuildImageFileName(pictureBox);
					pictureBox.Image.Save(Path.Combine(folderBrowserDialog.SelectedPath, imageFilename));
				}

				var promptFileName = BuildPromptFileName();
				File.WriteAllText(Path.Combine(folderBrowserDialog.SelectedPath, promptFileName), _prediction!.Input.Prompt);
			});
		}
	}

	private void buttonSaveAll_Click(object sender, EventArgs e)
	{
		ShowFolderBrowserDialog();
	}

	private void SetImage(Bitmap image)
	{
		foreach (var pictureBox in _pictureBoxes)
		{
			pictureBox.Image = image;
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

	private async Task ExecuteAsync(Func<Task> action, Action error)
	{
		try
		{
			ToggleButtons(false);
			await action();
		}
		catch
		{
			error();
		}
		finally
		{
			ToggleButtons(true);
			Refresh();
		}
	}
}