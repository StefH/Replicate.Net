using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Replicate.Net.Client;
using Replicate.Net.DependencyInjection.Options;
using Replicate.Net.Factory;
using RestEase.HttpClientFactory;
using Stef.Validation;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReplicateClient(this IServiceCollection services, Uri baseUrl, string? token = null)
    {
        Guard.NotNull(services);

        AddRestEaseClientInternal(services, new ReplicateClientOptions { BaseUrl = baseUrl, Token = token });

        return services;
    }

    public static IServiceCollection AddReplicateClient(this IServiceCollection services, string token)
    {
        Guard.NotNull(services);
        Guard.NotNull(token);

        AddRestEaseClientInternal(services, new ReplicateClientOptions { BaseUrl = ReplicateApiFactory.PredictionBaseUrl, Token = token });

        return services;
    }

    public static IServiceCollection AddReplicateClient(this IServiceCollection services, IConfigurationSection section)
    {
        Guard.NotNull(services);
        Guard.NotNull(section);

        var options = new ReplicateClientOptions();
        section.Bind(options);

        AddRestEaseClientInternal(services, options);

        return services;
    }

    public static IServiceCollection AddReplicateClient(this IServiceCollection services, Action<ReplicateClientOptions> optionBuilder)
    {
        Guard.NotNull(services);
        Guard.NotNull(optionBuilder);

        var options = new ReplicateClientOptions();
        optionBuilder(options);

        AddRestEaseClientInternal(services, options);

        return services;
    }

    public static void AddRestEaseClientInternal(IServiceCollection services, ReplicateClientOptions options)
    {
        Guard.NotNull(options);

        services.AddOptionsWithDataAnnotationValidation(options);

        var authenticationHeaderValue = !string.IsNullOrEmpty(options.Token) ?
            new AuthenticationHeaderValue(ReplicateApiFactory.AuthenticationScheme, options.Token) :
            null;

        services.AddRestEaseClient<IReplicateApi>(
            options.BaseUrl,
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