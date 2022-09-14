using Replicate.Net.Client;

namespace Replicate.Net.Factory;

public interface IPredictionsApiFactory
{
    IPredictionsApi GetClient(string url, string token);


    IPredictionsApi GetClient(string? token = null);
}