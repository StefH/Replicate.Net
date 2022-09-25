using Replicate.Net.Client;
using Replicate.Net.Factory;
using Replicate.Net.Models;

namespace Replicate.Net.WinFormsApp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private async void btnGenerate_Click(object sender, EventArgs e)
		{
			btnGenerate.Enabled = false;
			txtPrompt.Enabled = false;
			picture1.ImageLocation = string.Empty;
			picture2.ImageLocation = string.Empty;
			picture3.ImageLocation = string.Empty;
			picture4.ImageLocation = string.Empty;

			try
			{
				var factory = new InPainterApiFactory();
				var api = factory.GetApi();

				var input = new PredictionInput
				{
					Prompt = txtPrompt.Text
				};

				var prediction = await api.CreatePredictionAndWaitOnResultAsync(input);

				if (prediction is not null && prediction.GeneratedPictures is not null)
				{
					picture1.ImageLocation = prediction.GeneratedPictures[0];
					picture1.Refresh();

					picture2.ImageLocation = prediction.GeneratedPictures[1];
					picture3.ImageLocation = prediction.GeneratedPictures[2];
					picture4.ImageLocation = prediction.GeneratedPictures[3];
				}

				Refresh();
			}
			finally
			{
				txtPrompt.Enabled = true;
				btnGenerate.Enabled = true;
			}
		}
	}
}