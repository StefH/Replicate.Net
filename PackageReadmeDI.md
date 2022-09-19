## Info
A C# client (using [RestEase](https://github.com/canton7/RestEase)) for [Replicate](https://replicate.com): A latent text-to-image diffusion model capable of generating photo-realistic images given any text input.

## Example
``` c#
var services = new ServiceCollection();

services.AddReplicateClient(token);

var provider = services.BuildServiceProvider();

var replicateApi = provider.GetRequiredService<IReplicateApi>();

var predictions = await replicateApi.GetAllPredictionsAsync().ConfigureAwait(false);
Console.WriteLine("predictions = {0}", predictions?.Count);
```