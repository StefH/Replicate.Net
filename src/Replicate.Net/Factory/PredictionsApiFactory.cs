using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Client;
using RestEase;
using Stef.Validation;

namespace Replicate.Net.Factory;

public class PredictionsApiFactory : IPredictionsApiFactory
{
    private readonly string _token;

    public PredictionsApiFactory(string token)
    {
        _token = Guard.NotNullOrEmpty(token);
    }

    public IPredictionsApi GetClient()
    {
        var client = new RestClient("https://api.replicate.com/v1/predictions").For<IPredictionsApi>();

        client.Token = _token;

        return client;
    }
}