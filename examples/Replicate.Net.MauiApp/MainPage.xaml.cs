using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Common.Example.Client;
using Replicate.Net.Common.Example.Factory;
using Replicate.Net.MauiLib;
using Replicate.Net.Models;

namespace Replicate.Net.MauiApp;

public partial class MainPage : ContentPage
{
    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        Formatting = Formatting.Indented
    };

    private readonly IFolderPicker _folderPicker;

    private Prediction? _prediction;

    public MainPage(IFolderPicker folderPicker)
    {
        InitializeComponent();

        _folderPicker = folderPicker;
    }

    private async void OnGenerateClicked(object sender, EventArgs e)
    {
        SetLoading();

        var api = new ExampleApiFactory().GetApi();

        var input = new PredictionInput
        {
            Prompt = txtPrompt.Text
        };

        try
        {
            _prediction = await api.CreatePredictionAndWaitOnResultAsync(input);

            if (_prediction?.GeneratedPictures is not null)
            {
                picture0.Source = ImageSource.FromUri(new Uri(_prediction.GeneratedPictures[0]));
                picture1.Source = ImageSource.FromUri(new Uri(_prediction.GeneratedPictures[1]));
                picture2.Source = ImageSource.FromUri(new Uri(_prediction.GeneratedPictures[2]));
                picture3.Source = ImageSource.FromUri(new Uri(_prediction.GeneratedPictures[3]));
            }
            else
            {
                SetError();
            }
        }
        catch
        {
            SetError();
        }
    }

    private async void OnSaveAllClicked(object sender, EventArgs e)
    {
        var folder = await _folderPicker.PickFolderAsync();
        int x = 0;
        //foreach (var pictureBox in PictureBoxes)
        //{
        //    var imageFilename = BuildImageFileName(pictureBox);
        //    pictureBox.Image.Save(Path.Combine(folderBrowserDialog.SelectedPath, imageFilename));
        //}

        //var promptFileName = BuildPromptFileName();
        //SavePrompt(Path.Combine(folderBrowserDialog.SelectedPath, promptFileName));
    }

    private void SetLoading()
    {
        picture0.Source = picture1.Source = picture2.Source = picture3.Source = "loading.gif";
    }

    private void SetError()
    {
        picture0.Source = picture1.Source = picture2.Source = picture3.Source = "error.png";
    }

    private string BuildImageFileName(Image image)
    {
        return $"{_prediction!.Id}_{Path.GetFileName(image.Source.ToString())}";
    }

    private string BuildPromptFileName()
    {
        return $"{_prediction!.Id}_Prompt.txt";
    }
}