using Replicate.Net.Client;
using Replicate.Net.Settings;

namespace Replicate.Net.Factory;

public interface IPredictionsApiFactory
{
    IPredictionsApi GetClient(ClientSettings settings);


    IPredictionsApi GetClient(string token);
}