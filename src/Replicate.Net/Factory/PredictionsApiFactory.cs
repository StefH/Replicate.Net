using Replicate.Net.Client;
using RestEase;
using Stef.Validation;

namespace Replicate.Net.Factory;

public class PredictionsApiFactory : IPredictionsApiFactory
{
    private const string PredictionUrl = "https://api.replicate.com/v1/predictions";

    public IPredictionsApi GetClient(string url, string token)
    {
        var client = new RestClient(Guard.NotNullOrEmpty(url)).For<IPredictionsApi>();
        client.Token = Guard.NotNullOrEmpty(token);
        return client;
    }


    public IPredictionsApi GetClient(string? token = null)
    {
        var client = new RestClient(PredictionUrl).For<IPredictionsApi>();

        if (!string.IsNullOrEmpty(token))
        {
            client.Token = token;
        }

        return client;
    }
}