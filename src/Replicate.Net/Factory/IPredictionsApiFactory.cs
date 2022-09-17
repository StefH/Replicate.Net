using System;
using Replicate.Net.Client;

namespace Replicate.Net.Factory;

public interface IReplicateApiFactory
{
    IReplicateApi GetApi(Uri baseUrl, string? token = null);
    
    IReplicateApi GetApi(string token);
}