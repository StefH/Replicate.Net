using System;
using Replicate.Net.Client;

namespace Replicate.Net.Factory;

public interface IPredictionsApiFactory
{
    IPredictionsApi GetClient(Uri baseUrl, string? token = null);
    
    IPredictionsApi GetClient(string token);
}