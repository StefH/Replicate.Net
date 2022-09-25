using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Client;
using Replicate.Net.Factory;
using Replicate.Net.Models;

var settings = new JsonSerializerSettings
{
    ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
    },
    Formatting = Formatting.Indented
};

try
{
    await RunOnInPainterVercelAppUsingFactoryAsync().ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

return;

var token = Environment.GetEnvironmentVariable("replicate_token")!;

try
{
    await RunOnReplicateUsingDependencyInjectionAsync().ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

try
{
    await RunOnReplicateUsingFactoryAsync().ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

// -------------------------------------------------------------------------------------------------------------
async Task RunOnInPainterVercelAppUsingFactoryAsync()
{
    var factory = new InPainterApiFactory();

    var api = factory.GetApi();

    var input = new PredictionInput
    {
        Prompt = "Artificial intelligence female face android, high detail graphics, cinematic lights, 4k, artstation, hyperrealistic, intricate details, Powerful, Rim Lighting, Diffraction Grading, RTX, by Ivan Shishkin-2"
    };

    var response = await api.CreatePredictionAndWaitOnResultAsync(input).ConfigureAwait(false);
    Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
}

// -------------------------------------------------------------------------------------------------------------
async Task RunOnReplicateUsingDependencyInjectionAsync()
{
    var services = new ServiceCollection();

    services.AddReplicateClient(options =>
    {
        options.Token = token;
    });

    var provider = services.BuildServiceProvider();

    var replicateApi = provider.GetRequiredService<IReplicateApi>();

    var predictions = await replicateApi.GetAllPredictionsAsync().ConfigureAwait(false);
    Console.WriteLine("predictions = {0}", predictions?.Count);

    var model = await replicateApi.GetModelAsync("cjwbw", "stable-diffusion-high-resolution").ConfigureAwait(false);
    Console.WriteLine(JsonConvert.SerializeObject(model, settings));
}

// -------------------------------------------------------------------------------------------------------------
async Task RunOnReplicateUsingFactoryAsync()
{
    var factory = new ReplicateApiFactory();

    var replicateApi = factory.GetApi(token);

    var predictions = await replicateApi.GetAllPredictionsAsync().ConfigureAwait(false);
    Console.WriteLine("predictions = {0}", predictions?.Count);

    var model = await replicateApi.GetModelAsync("cjwbw", "stable-diffusion-high-resolution").ConfigureAwait(false);
    Console.WriteLine(JsonConvert.SerializeObject(model, settings));

    var modelVersions = await replicateApi.GetAllModelVersionsAsync("cjwbw", "stable-diffusion-high-resolution").ConfigureAwait(false);
    Console.WriteLine("modelVersions = {0}", modelVersions?.Count);

    var collections = await replicateApi.GetCollectionsAsync("super-resolution").ConfigureAwait(false);
    Console.WriteLine("collections = {0}", collections.Models?.Count);

    return;

    var requestStableDiffusion = new Request
    {
        Version = "a9758cbfbd5f3c2094457d996681af52552901775aa2d6dd0b17fd15df959bef",
        Input = new PredictionInput
        {
            Prompt = "a gentleman cat with blue eyes wearing a top-hat in a 19th century portrait"
        }
    };
    var response1 = await replicateApi.CreatePredictionAndWaitOnResultAsync(requestStableDiffusion).ConfigureAwait(false);
    Console.WriteLine(JsonConvert.SerializeObject(response1, Formatting.Indented));

    var requestcjwbw = new Request
    {
        Version = "6cba009c63dce77592f864a4d3584ec21c59d92f4ba2da78319ada831e3725fc",
        Input = new PredictionInput
        {
            Prompt = "female cyborg assimilated by alien plants, intricate Two-point lighting portrait, by Ching Yeh and Greg Rutkowski, detailed cyberpunk in the style of GitS 1995"
        }
    };
    var response2 = await replicateApi.CreatePredictionAndWaitOnResultAsync(requestcjwbw).ConfigureAwait(false);
    Console.WriteLine(JsonConvert.SerializeObject(response2, settings));
}