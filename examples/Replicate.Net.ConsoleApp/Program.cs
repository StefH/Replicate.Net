﻿using Newtonsoft.Json;
using Replicate.Net.Client;
using Replicate.Net.Factory;
using Replicate.Net.Models.Predictions;

var factory = new PredictionsApiFactory();

var version = "a9758cbfbd5f3c2094457d996681af52552901775aa2d6dd0b17fd15df959bef";
var prompt = "a gentleman cat with blue eyes wearing a tophat in a 19th century portrait";

// await RunOnLocalAsync(factory).ConfigureAwait(false);

await RunOnPredictionsAsync(factory).ConfigureAwait(false);

// -------------------------------------------------------------------------------------------------------------

async Task RunOnLocalAsync(IPredictionsApiFactory factory)
{
    var client = factory.GetClient("https://localhost:5000");

    var request = new Request
    {
        Version = version,
        Input = new Input
        {
            Prompt = prompt
        }
    };

    var predictions = await client.GetPredictionsAsync().ConfigureAwait(false);
    Console.WriteLine("predictions = {0}", predictions.Results?.Count);

    var response = await client.CreatePredictionAndWaitOnResultAsync(request).ConfigureAwait(false);

    Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
}


async Task RunOnPredictionsAsync(IPredictionsApiFactory factory)
{
    var client = factory.GetClient(Environment.GetEnvironmentVariable("replicate_token")!);

    var request = new Request
    {
        Version = version,
        Input = new Input
        {
            Prompt = prompt
        }
    };

    var predictions = await client.GetPredictionsAsync().ConfigureAwait(false);
    Console.WriteLine("predictions = {0}", predictions.Results?.Count);

    var response = await client.CreatePredictionAndWaitOnResultAsync(request).ConfigureAwait(false);

    Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
}