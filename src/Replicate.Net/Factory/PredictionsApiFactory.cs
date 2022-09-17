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

        var api = new RestClient(baseUrl)
        {
            JsonSerializerSettings = Settings
        }
        .For<IReplicateApi>();

        if (!string.IsNullOrEmpty(token))
        {
            api.Token = token;
        }

        return api;
    }

    public IReplicateApi GetApi(string token)
    {
        return GetApi(PredictionBaseUrl, token);
    }
}