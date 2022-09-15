using System;
using Replicate.Net.Client;
using RestEase;
using Stef.Validation;

namespace Replicate.Net.Factory;

public class PredictionsApiFactory : IPredictionsApiFactory
{
    private static readonly Uri PredictionBaseUrl = new("https://api.replicate.com/v1/predictions");

    public IPredictionsApi GetClient(Uri baseUrl, string? token = null)
    {
        Guard.NotNull(baseUrl);

        var client = new RestClient(baseUrl).For<IPredictionsApi>();

        if (!string.IsNullOrEmpty(token))
        {
            client.Token = token;
        }

        return client;
    }

    public IPredictionsApi GetClient(string token)
    {
        return GetClient(PredictionBaseUrl, token);
    }
}