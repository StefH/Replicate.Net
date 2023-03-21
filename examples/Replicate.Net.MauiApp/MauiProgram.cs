using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Replicate.Net.Common.Example.Factory;

namespace Replicate.Net.MauiApp;

public static class MauiProgram
{
    public static Microsoft.Maui.Hosting.MauiApp CreateMauiApp()
    {
        var builder = Microsoft.Maui.Hosting.MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()

            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()

            // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Configuration.AddEnvironmentVariables();

        builder.Services.AddHttpClient();

        // services
        builder.Services.AddSingleton<IExampleApiFactory, ExampleApiFactory>();

        // pages
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<App>();

        return builder.Build();
    }
}