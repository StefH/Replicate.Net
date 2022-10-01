using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Client;
using Replicate.Net.Common.Example.Client;
using Replicate.Net.Common.Example.Factory;
using Replicate.Net.Models;

namespace Replicate.Net.WinFormsApp;

public partial class MainForm : Form
{
    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        Formatting = Formatting.Indented
    };

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IExampleApiFactory _exampleApiFactory;
    private readonly IReplicateApi _replicateApi;

    private Prediction? _prediction;

    private PictureBox[] PictureBoxes => Controls.OfType<PictureBox>().ToArray();

    public MainForm(
        IHttpClientFactory httpClientFactory,
        IExampleApiFactory exampleApiFactory,
        IReplicateApi replicateApi
    )
    {
        InitializeComponent();

        _httpClientFactory = httpClientFactory;
        _exampleApiFactory = exampleApiFactory;
        _replicateApi = replicateApi;
        buttonSaveAll.Enabled = false;
    }

    private async void btnGenerate_Click(object sender, EventArgs e)
    {
        await ExecuteAsync
        (
            async () =>
            {
                SetImage(Resources.Loading);

                _prediction = await CreatePredictionAndWaitOnResultAsync();

                if (_prediction?.GeneratedPictures is not null)
                {
                    var tasks = new[]
                    {
                        SetImageAsync(picture0, _prediction.GeneratedPictures[0]),
                        SetImageAsync(picture1, _prediction.GeneratedPictures[1]),
                        SetImageAsync(picture2, _prediction.GeneratedPictures[2]),
                        SetImageAsync(picture3, _prediction.GeneratedPictures[3]),
                    };

                    await Task.WhenAll(tasks);
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

    private async Task<Prediction> CreatePredictionAndWaitOnResultAsync()
    {
        var input = new PredictionInput
        {
            Prompt = txtPrompt.Text,
            Width = int.Parse(cmbWidth.Text),
            Height = int.Parse(cmbHeight.Text),
            Seed = int.TryParse(txtSeed.Text, out var seed) ? seed : null
        };

        switch (cmbProvider.Text)
        {
            case "custom":
                var api = _exampleApiFactory.GetApi();
                return await api.CreatePredictionAndWaitOnResultAsync(input);

            case "replicate.com":
                var request = new Request
                {
                    Version = "a9758cbfbd5f3c2094457d996681af52552901775aa2d6dd0b17fd15df959bef",
                    Input = input
                };

                return await _replicateApi.CreatePredictionAndWaitOnResultAsync(request);

            default:
                throw new InvalidCastException();
        }
    }

    private string BuildImageFileName(PictureBox pictureBox)
    {
        return $"{_prediction!.Id}_{pictureBox.Name}.png";
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

        if (DialogResult.OK == saveFileDialog.ShowDialog())
        {
            Execute(() =>
            {
                pictureBox.Image.Save(saveFileDialog.FileName);
                SavePrompt(Path.Combine(Path.GetDirectoryName(saveFileDialog.FileName)!, promptFileName));
            });
        }
    }

    private void ShowFolderBrowserDialog()
    {
        var folderBrowserDialog = new FolderBrowserDialog();
        if (DialogResult.OK == folderBrowserDialog.ShowDialog())
        {
            Execute(() =>
            {
                foreach (var pictureBox in PictureBoxes)
                {
                    var imageFilename = BuildImageFileName(pictureBox);
                    pictureBox.Image.Save(Path.Combine(folderBrowserDialog.SelectedPath, imageFilename));
                }

                var promptFileName = BuildPromptFileName();
                SavePrompt(Path.Combine(folderBrowserDialog.SelectedPath, promptFileName));
            });
        }
    }

    private void buttonSaveAll_Click(object sender, EventArgs e)
    {
        ShowFolderBrowserDialog();
    }

    private void SetImage(Image image)
    {
        foreach (var pictureBox in PictureBoxes)
        {
            pictureBox.Image = null;
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.Image = image;
        }
    }

    private Task SetImageAsync(PictureBox pictureBox, string url)
    {
        return Task.Run(async () =>
        {
            var httpClient = _httpClientFactory.CreateClient();
            var stream = await httpClient.GetStreamAsync(url);

            pictureBox.Image = Image.FromStream(stream);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        });
    }

    private void ToggleButtons(bool show)
    {
        btnGenerate.Enabled = show;
        buttonSaveAll.Enabled = show;
        txtPrompt.Enabled = show;
        cmbProvider.Enabled = show;
        cmbHeight.Enabled = show;
        cmbWidth.Enabled = show;
        txtSeed.Enabled = show;
    }

    private void SavePrompt(string fileName)
    {
        File.WriteAllText(fileName, JsonConvert.SerializeObject(_prediction, _jsonSerializerSettings));
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