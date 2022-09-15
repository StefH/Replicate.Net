using AnyOfTypes.Newtonsoft.Json;
using Newtonsoft.Json;
using Replicate.Net.Client;
using Replicate.Net.Factory;
using Replicate.Net.Predictions;

var factory = new ReplicateApiFactory();

var version = "a9758cbfbd5f3c2094457d996681af52552901775aa2d6dd0b17fd15df959bef";
var prompt = "a gentleman cat with blue eyes wearing a tophat in a 19th century portrait";

//try
//{
//    await RunOnLocalAsync().ConfigureAwait(false);
//}
//catch (Exception e)
//{
//    Console.WriteLine(e);
//}

try
{
    await RunOnPredictionsAsync().ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

// -------------------------------------------------------------------------------------------------------------

//async Task RunOnLocalAsync()
//{
//    var client = factory.GetApi(new Uri("http://localhost:5000"));

//    var request = new Request
//    {
//        Version = version,
//        Input = new Input
//        {
//            Prompt = prompt
//        }
//    };

//    var response = await client.CreatePredictionAndWaitOnResultAsync(request).ConfigureAwait(false);

//    Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented, new AnyOfJsonConverter()));
//}


async Task RunOnPredictionsAsync()
{
    var client = factory.GetApi(Environment.GetEnvironmentVariable("replicate_token")!);

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

    Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented, new AnyOfJsonConverter()));
}