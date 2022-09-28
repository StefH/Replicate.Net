using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Replicate.Net.Common.Example.Factory;

namespace Replicate.Net.WinFormsApp;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var serviceProvider = ConfigureServices();

        Application.Run(serviceProvider.GetRequiredService<MainForm>());
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();
        services.AddSingleton<MainForm>();

        services.AddSingleton<IConfiguration>(sp =>
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddEnvironmentVariables();

            return configurationBuilder.Build();
        });

        services.AddSingleton<IExampleApiFactory, ExampleApiFactory>();
        services.AddReplicateClient(Environment.GetEnvironmentVariable("replicate_token")!);

        return services.BuildServiceProvider();
    }
}