using Microsoft.Extensions.DependencyInjection;
using Replicate.Net.Common.Example.Factory;
using Replicate.Net.MauiLib;
using Replicate.Net.MauiLib.Platforms.Windows;

namespace Replicate.Net.MauiApp;

public static class MauiProgram
{
    public static Microsoft.Maui.Hosting.MauiApp CreateMauiApp()
    {
        var builder = Microsoft.Maui.Hosting.MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IFolderPicker, FolderPicker>();

        builder.Services.AddSingleton<IExampleApiFactory, ExampleApiFactory>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<App>();

        return builder.Build();
    }
}