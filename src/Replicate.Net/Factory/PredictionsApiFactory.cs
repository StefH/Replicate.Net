using System;
using Replicate.Net.Client;
using RestEase;
using Stef.Validation;

namespace Replicate.Net.Factory;

public class ReplicateApiFactory : IReplicateApiFactory
{
    private static readonly Uri PredictionBaseUrl = new("https://api.replicate.com/v1");

    public IReplicateApi GetApi(Uri baseUrl, string? token = null)
    {
        Guard.NotNull(baseUrl);

        var client = new RestClient(baseUrl).For<IReplicateApi>();

        if (!string.IsNullOrEmpty(token))
        {
            client.Token = token;
        }

        return client;
    }

    public IReplicateApi GetApi(string token)
    {
        return GetApi(PredictionBaseUrl, token);
    }
}