using CommunityToolkit.Maui.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Common.Example.Client;
using Replicate.Net.Common.Example.Factory;
using Replicate.Net.Models;
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

        var input = new DefaultPredictionInput
        {
            Prompt = txtPrompt.Text
        };

        try
        {
            _prediction = await api.CreatePredictionAndWaitOnResultAsync(input);

            if (_prediction?.GeneratedPictures is not null)
            {
                LoadImageSourceFromUrl(picture0, _prediction.GeneratedPictures[0]);
                LoadImageSourceFromUrl(picture1, _prediction.GeneratedPictures[1]);
                LoadImageSourceFromUrl(picture2, _prediction.GeneratedPictures[2]);
                LoadImageSourceFromUrl(picture3, _prediction.GeneratedPictures[3]);

                btnGenerate.IsEnabled = true;
                btnSaveAll.IsEnabled = true;
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

    private void LoadImageSourceFromUrl(MauiImage image, string url)
    {
        image.Source = ImageSource.FromStream(async ct =>
        {
            var httpClient = _httpClientFactory.CreateClient();
            var bytes = await httpClient.GetByteArrayAsync(url, ct);
            return new MemoryStream(bytes);
        });
    }

    private async void OnSaveAllClicked(object sender, EventArgs e)
    {
        var folderPickerResult = await FolderPicker.PickAsync(CancellationToken.None);
        if (folderPickerResult.IsSuccessful)
        {
            btnSaveAll.IsEnabled = false;
            foreach (var image in Images)
            {
                var imageFilename = BuildImageFileName(image);
                var stream = await ((IStreamImageSource)image.Source).GetStreamAsync();
                stream.Position = 0;
                await using var fileStream = new FileStream(Path.Combine(folderPickerResult.Folder.Path, imageFilename), FileMode.Create);

                await stream.CopyToAsync(fileStream);
            }

            var promptFileName = BuildPromptFileName();
            SavePrompt(Path.Combine(folderPickerResult.Folder.Path, promptFileName));

            btnSaveAll.IsEnabled = true;
        }
    }

    private void SetLoading()
    {
        picture0.Source = picture1.Source = picture2.Source = picture3.Source = "loading.gif";

        btnGenerate.IsEnabled = false;
        btnSaveAll.IsEnabled = false;
    }

    private void SetError()
    {
        picture0.Source = picture1.Source = picture2.Source = picture3.Source = "error.png";

        btnGenerate.IsEnabled = true;
        btnSaveAll.IsEnabled = false;
    }

    private string BuildImageFileName(MauiImage image)
    {
        //return $"{_prediction!.Id}_{Path.GetFileName(image.Source.ToString())}";
        return $"{_prediction!.Id}_picture{image.Id}.png";
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