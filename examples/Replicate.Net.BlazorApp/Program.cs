using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Replicate.Net.BlazorApp;
using Replicate.Net.Common.Example.Factory;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IExampleApiFactory, ExampleApiFactory>();

builder.Services.AddReplicateClient(builder.Configuration.GetRequiredSection("ReplicateClientOptions"));

await builder.Build().RunAsync();