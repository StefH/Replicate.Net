using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Replicate.Net.Client;
using Replicate.Net.Factory;
using RestEase.HttpClientFactory;
using Stef.Validation;

namespace Microsoft.Extensions.DependencyInjection;

// ReSharper disable once InconsistentNaming
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReplicateClient(this IServiceCollection services, Uri baseUrl, string? token = null)
    {
        Guard.NotNull(services);
        Guard.NotNull(baseUrl);

        AddRestEaseClientInternal(services, baseUrl, token);

        return services;
    }

    public static IServiceCollection AddReplicateClient(this IServiceCollection services, string token)
    {
        Guard.NotNull(services);
        Guard.NotNull(token);

        AddRestEaseClientInternal(services, ReplicateApiFactory.PredictionBaseUrl, token);

        return services;
    }

    private static void AddRestEaseClientInternal(IServiceCollection services, Uri baseUrl, string? token)
    {
        var authenticationHeaderValue = !string.IsNullOrEmpty(token) ?
            new AuthenticationHeaderValue(ReplicateApiFactory.AuthenticationScheme, token) :
            null;

        services.AddRestEaseClient<IReplicateApi>(
            baseUrl,
            client =>
            {
                client.JsonSerializerSettings = ReplicateApiFactory.Settings;
            },
            (request, _) =>
            {
                if (authenticationHeaderValue is { })
                {
                    request.Headers.Authorization = authenticationHeaderValue;
                }

                return Task.CompletedTask;
            });
    }
}