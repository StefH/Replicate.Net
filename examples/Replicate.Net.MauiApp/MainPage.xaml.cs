using CommunityToolkit.Maui.Storage;
using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Common.Example.Client;
using Replicate.Net.Common.Example.Factory;
using Replicate.Net.Models;
using Windows.Storage.Streams;
using MauiImage = Microsoft.Maui.Controls.Image;

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

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IExampleApiFactory _exampleApiFactory;

    private Prediction? _prediction;

    private StreamImageSource? _streamImageSource0;
    private StreamImageSource? _streamImageSource1;
    private StreamImageSource? _streamImageSource2;
    private StreamImageSource? _streamImageSource3;

    private MauiImage[] Images => this.GetVisualTreeDescendants().OfType<MauiImage>().ToArray();

    public MainPage(IExampleApiFactory exampleApiFactory, IHttpClientFactory httpClientFactory)
    {
        InitializeComponent();

        _exampleApiFactory = exampleApiFactory;
        _httpClientFactory = httpClientFactory;
    }

    private async void OnGenerateClicked(object sender, EventArgs e)
    {
        SetLoading();

        var api = _exampleApiFactory.GetApi();

        var input = new PredictionInput
        {
            Prompt = txtPrompt.Text
        };

        try
        {
            _prediction = await api.CreatePredictionAndWaitOnResultAsync(input);

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

                //picture0.Source = ImageSource.FromUri(new Uri(_prediction.GeneratedPictures[0]));
                //picture1.Source = ImageSource.FromUri(new Uri(_prediction.GeneratedPictures[1]));
                //picture2.Source = ImageSource.FromUri(new Uri(_prediction.GeneratedPictures[2]));
                //picture3.Source = ImageSource.FromUri(new Uri(_prediction.GeneratedPictures[3]));
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

    private Task SetImageAsync(MauiImage pictureBox, string url)
    {
        return Task.Run(() =>
        {
            var httpClient = _httpClientFactory.CreateClient();

            pictureBox.Source = ImageSource.FromStream(ct => httpClient.GetStreamAsync(url, ct));
        });
    }

    private async void OnSaveAllClicked(object sender, EventArgs e)
    {
        var folderPickerResult = await FolderPicker.PickAsync(CancellationToken.None);
        if (folderPickerResult.IsSuccessful)
        {
            foreach (var image in Images)
            {
                var imageFilename = BuildImageFileName(image);
                var stream = await ((IStreamImageSource)image.Source).GetStreamAsync();
                await using var fileStream = new FileStream(Path.Combine(folderPickerResult.Folder.Path, imageFilename), FileMode.Create);

                await stream.CopyToAsync(fileStream);
            }

            var promptFileName = BuildPromptFileName();
            SavePrompt(Path.Combine(folderPickerResult.Folder.Path, promptFileName));
        }
    }

    private void SetLoading()
    {
        picture0.Source = picture1.Source = picture2.Source = picture3.Source = "loading.gif";
    }

    private void SetError()
    {
        picture0.Source = picture1.Source = picture2.Source = picture3.Source = "error.png";
    }

    private string BuildImageFileName(MauiImage image)
    {
        return $"{_prediction!.Id}_{Path.GetFileName(image.Source.ToString())}";
    }

    private string BuildPromptFileName()
    {
        return $"{_prediction!.Id}_Prompt.txt";
    }

    private void SavePrompt(string fileName)
    {
        File.WriteAllText(fileName, JsonConvert.SerializeObject(_prediction, _jsonSerializerSettings));
    }
}