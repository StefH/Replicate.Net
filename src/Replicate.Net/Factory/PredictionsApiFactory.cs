using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Client;
using RestEase;
using Stef.Validation;

namespace Replicate.Net.Factory;

public class ReplicateApiFactory : IReplicateApiFactory
{
    public const string AuthenticationScheme = "Token";
    public static readonly Uri PredictionBaseUrl = new("https://api.replicate.com/v1");

    public static readonly JsonSerializerSettings Settings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
    };

    public IReplicateApi GetApi(Uri baseUrl, string? token = null)
    {
        Guard.NotNull(baseUrl);

        var authenticationHeaderValue = !string.IsNullOrEmpty(token) ?
            new AuthenticationHeaderValue(ReplicateApiFactory.AuthenticationScheme, token) :
            null;

        return new RestClient
        (
            baseUrl,
            (request, _) =>
            {
                if (authenticationHeaderValue is { })
                {
                    request.Headers.Authorization = authenticationHeaderValue;
                }
                return Task.CompletedTask;
            }
        )
        {
            JsonSerializerSettings = Settings
        }
        .For<IReplicateApi>();
    }

    public IReplicateApi GetApi(string token)
    {
        return GetApi(PredictionBaseUrl, token);
    }
}