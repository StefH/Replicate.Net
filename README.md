# Replicate.Net
A C# RestEase client for Replicate (A latent text-to-image diffusion model capable of generating photo-realistic images given any text input).

## Install
[![NuGet Badge](https://buildstats.info/nuget/Replicate.Net)](https://www.nuget.org/packages/Replicate.Net)

## Example
``` c#
var factory = new PredictionsApiFactory();

var replicateApi = factory.GetApi("{token}");

var request = new Request
{
    Version = "a9758cbfbd5f3c2094457d996681af52552901775aa2d6dd0b17fd15df959bef",
    Input = new Input
    {
        Prompt = "a gentleman cat with blue eyes wearing a tophat in a 19th century portrait"
    }
};

var response = await replicateApi.CreatePredictionAndWaitOnResultAsync(request).ConfigureAwait(false);
```