using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Client;
using Replicate.Net.Common.Example.Client;
using Replicate.Net.Common.Example.Factory;
using Replicate.Net.Factory;
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

    private Prediction? _prediction;

    private PictureBox[] PictureBoxes => Controls.OfType<PictureBox>().ToArray();

    public MainForm()
    {
        InitializeComponent();
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
                    picture0.ImageLocation = _prediction.GeneratedPictures[0];
                    picture1.ImageLocation = _prediction.GeneratedPictures[1];
                    picture2.ImageLocation = _prediction.GeneratedPictures[2];
                    picture3.ImageLocation = _prediction.GeneratedPictures[3];
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

    private void cmdProvider_SelectedIndexChanged(object sender, EventArgs e)
    {
        var cmd = (ComboBox)sender;

        
    }

    private async Task<Prediction> CreatePredictionAndWaitOnResultAsync()
    {
        switch (cmdProvider.Text)
        {
            case "custom":
                {
                    var api = new ExampleApiFactory().GetApi();

                    var input = new PredictionInput
                    {
                        Prompt = txtPrompt.Text
                    };

                    return await api.CreatePredictionAndWaitOnResultAsync(input);
                }

            case "replicate.com":
                {
                    var api = new ReplicateApiFactory().GetApi(Environment.GetEnvironmentVariable("replicate_token")!);

                    var request = new Request
                    {
                        Version = "a9758cbfbd5f3c2094457d996681af52552901775aa2d6dd0b17fd15df959bef",
                        Input = new PredictionInput
                        {
                            Prompt = txtPrompt.Text
                        }
                    };

                    return await api.CreatePredictionAndWaitOnResultAsync(request);
                }

            default:
                throw new InvalidCastException();
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
            pictureBox.Image = image;
            pictureBox.ImageLocation = string.Empty;
        }
    }

    private void ToggleButtons(bool show)
    {
        btnGenerate.Enabled = show;
        buttonSaveAll.Enabled = show;
        txtPrompt.Enabled = show;
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