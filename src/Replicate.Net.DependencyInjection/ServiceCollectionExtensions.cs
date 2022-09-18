using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Replicate.Net.Client;
using Replicate.Net.Factory;
using RestEase.HttpClientFactory;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReplicateClient(this IServiceCollection services, Uri baseUrl, string? token = null)
    {
        AddRestEaseClientInternal(services, baseUrl, token);

        return services;
    }

    public static IServiceCollection AddReplicateClient(this IServiceCollection services, string token)
    {
        AddRestEaseClientInternal(services, ReplicateApiFactory.PredictionBaseUrl, token);

        return services;
    }

    private static void AddRestEaseClientInternal(IServiceCollection services, Uri baseUrl, string? token)
    {
        services.AddRestEaseClient<IReplicateApi>(
            baseUrl,
            client =>
            {
                client.JsonSerializerSettings = ReplicateApiFactory.Settings;
            },
            (request, cancellationToken) =>
            {
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue(ReplicateApiFactory.AuthenticationScheme, token);
                }

                return Task.CompletedTask;
            });
    }
}