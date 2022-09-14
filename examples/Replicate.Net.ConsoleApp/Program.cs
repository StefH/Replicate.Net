using Newtonsoft.Json;
using Replicate.Net.Client;
using Replicate.Net.Factory;
using Replicate.Net.Models.Predictions;

IPredictionsApiFactory factory = new PredictionsApiFactory();

var client = factory.GetClient(Environment.GetEnvironmentVariable("replicate_token")!);

var request = new Request
{
    Version = "a9758cbfbd5f3c2094457d996681af52552901775aa2d6dd0b17fd15df959bef",
    Input = new Input
    {
        Prompt = "a gentleman cat with blue eyes wearing a tophat in a 19th century portrait"
    }
};

var predictions = await client.GetPredictionsAsync();
Console.WriteLine("predictions = {0}", predictions.Results?.Count);

var response = await client.CreatePredictionAndWaitOnResultAsync(request).ConfigureAwait(false);

Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));