using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Common.Example.Client;
using RestEase;

namespace Replicate.Net.Common.Example.Factory;

public class ExampleApiFactory : IExampleApiFactory
{
    public static readonly JsonSerializerSettings Settings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
    };

    private readonly Uri _predictionBaseUrl;

    public ExampleApiFactory(IConfiguration configuration)
    {
        _predictionBaseUrl = new Uri(configuration["ExamplePredictionBaseUrl"]);
    }

    public IExampleApi GetApi()
    {
        return new RestClient(_predictionBaseUrl)
        {
            JsonSerializerSettings = Settings
        }
        .For<IExampleApi>();
    }
}