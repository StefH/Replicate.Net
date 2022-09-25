using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Client;
using RestEase;

namespace Replicate.Net.Factory;

public class InPainterApiFactory : IInPainterApiFactory
{
    public static readonly Uri PredictionBaseUrl = new("https://inpainter.vercel.app/api");

    public static readonly JsonSerializerSettings Settings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
    };

    public IInPainterApi GetApi()
    {
        return new RestClient(PredictionBaseUrl)
        {
            JsonSerializerSettings = Settings
        }
        .For<IInPainterApi>();
    }
}