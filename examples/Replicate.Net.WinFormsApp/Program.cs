using Microsoft.Extensions.DependencyInjection;

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
        return services.BuildServiceProvider();
    }
}