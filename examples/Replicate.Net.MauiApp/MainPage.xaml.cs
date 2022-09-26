using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Replicate.Net.Models;
using Microsoft.Maui.Graphics;
using Replicate.Net.Common.Example.Client;
using Replicate.Net.Common.Example.Factory;

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

    private Prediction? _prediction;

    public MainPage()
    {
        InitializeComponent();
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

    }

    private void SetLoading()
    {
        picture0.Source = picture1.Source = picture2.Source = picture3.Source = "loading.gif";
    }

    private void SetError()
    {
        picture0.Source = picture1.Source = picture2.Source = picture3.Source = "error.png";
    }
}