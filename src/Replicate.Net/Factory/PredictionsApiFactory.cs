using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Client;
using RestEase;
using Stef.Validation;

namespace Replicate.Net.Factory;

public class ReplicateApiFactory : IReplicateApiFactory
{
    private static readonly Uri PredictionBaseUrl = new("https://api.replicate.com/v1");

    private static readonly JsonSerializerSettings Settings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
    };

    public IReplicateApi GetApi(Uri baseUrl, string? token = null)
    {
        Guard.NotNull(baseUrl);

        var client = new RestClient(baseUrl)
        {
            JsonSerializerSettings = Settings
        }
        .For<IReplicateApi>();

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