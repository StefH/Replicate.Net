using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Replicate.Net.Client;
using Replicate.Net.Constants;
using Replicate.Net.Models;
using Stef.Validation;

namespace Replicate.Net.Common.Example.Client;

public static class IExampleApiExtensions
{
    public static async Task<Prediction> CreatePredictionAndWaitOnResultAsync(this IExampleApi api, PredictionInput input, int timeoutInSeconds = 5 * 60, CancellationToken cancellationToken = default)
    {
        Guard.NotNull(api);
        Guard.NotNull(input);

        var createPredictionResponse = await api.CreatePredictionAsync(input, cancellationToken).ConfigureAwait(false);

        return await IReplicateApiExtensions.CallAsync(
            timeoutInSeconds,
            async ct => await api.GetPredictionAsync(createPredictionResponse.Id, ct).ConfigureAwait(false),
            async ct => await api.CancelPredictionAsync(createPredictionResponse.Id, ct).ConfigureAwait(false),
            result => ReplicateConstants.RunningStates.Any(s => string.Equals(s, result.Status, StringComparison.OrdinalIgnoreCase)),
            cancellationToken
        );
    }
}