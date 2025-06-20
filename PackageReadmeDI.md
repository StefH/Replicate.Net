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

### Sponsors

[Entity Framework Extensions](https://entityframework-extensions.net/?utm_source=StefH) and [Dapper Plus](https://dapper-plus.net/?utm_source=StefH) are major sponsors and proud to contribute to the development of **Replicate.Net.DependencyInjection**.

[![Entity Framework Extensions](https://raw.githubusercontent.com/StefH/resources/main/sponsor/entity-framework-extensions-sponsor.png)](https://entityframework-extensions.net/bulk-insert?utm_source=StefH)

[![Dapper Plus](https://raw.githubusercontent.com/StefH/resources/main/sponsor/dapper-plus-sponsor.png)](https://dapper-plus.net/bulk-insert?utm_source=StefH)