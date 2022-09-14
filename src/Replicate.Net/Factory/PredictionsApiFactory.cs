using Replicate.Net.Client;
using Replicate.Net.Settings;
using RestEase;
using Stef.Validation;

namespace Replicate.Net.Factory;

public class PredictionsApiFactory : IPredictionsApiFactory
{
    private const string PredictionUrl = "https://api.replicate.com/v1/predictions";

    public IPredictionsApi GetClient(ClientSettings settings)
    {
        Guard.NotNull(settings);

        var url = !string.IsNullOrEmpty(settings.Url) ? settings.Url : PredictionUrl;
        var client = new RestClient(url).For<IPredictionsApi>();

        if (!string.IsNullOrEmpty(settings.Token))
        {
            client.Token = settings.Token;
        }

        return client;
    }

    public IPredictionsApi GetClient(string token)
    {
        return GetClient(new ClientSettings { Token = token });
    }
}