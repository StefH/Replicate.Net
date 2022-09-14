using Replicate.Net.Client;

namespace Replicate.Net.Factory;

public interface IPredictionsApiFactory
{
    IPredictionsApi GetClient();
}