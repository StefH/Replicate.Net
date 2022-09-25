# ![Project Icon](https://raw.githubusercontent.com/StefH/Replicate.Net/main/resources/icon_32x32.png) Replicate.Net
A C# client (using [RestEase](https://github.com/canton7/RestEase)) for [Replicate](https://replicate.com): A latent text-to-image diffusion model capable of generating photo-realistic images given any text input.

## Install
| | |
| - | - |
| [![NuGet Badge](https://buildstats.info/nuget/Replicate.Net)](https://www.nuget.org/packages/Replicate.Net) | Main project
| [![NuGet Badge](https://buildstats.info/nuget/Replicate.Net.DependencyInjection)](https://www.nuget.org/packages/Replicate.Net.DependencyInjection) | Support for Microsoft DependencyInjection

## Example (using Factory)
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

## Example (using DependencyInjection)
``` c#
// ---
    services.AddReplicateClient("{token}");
// ---


var replicateApi = // injected

// Now call the api
```

## Example WinForms application

![example-winform](./Resources/example-winform.png)