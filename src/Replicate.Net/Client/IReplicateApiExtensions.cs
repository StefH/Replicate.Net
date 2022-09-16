using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Replicate.Net.Predictions;
using Stef.Validation;

namespace Replicate.Net.Client;

// ReSharper disable once InconsistentNaming
public static class IReplicateApiExtensions
{
    private const int WaitTimeInSeconds = 3;
    private static readonly string[] RunningStates = { "starting", "processing" };

    public static async Task<Result> CreatePredictionAndWaitOnResultAsync(this IReplicateApi api, object requestAsObject, int timeoutInSeconds = 60, CancellationToken cancellationToken = default)
    {
        Guard.NotNull(api);
        Guard.NotNull(requestAsObject);

        var createPredictionAsync = requestAsObject switch
        {
            Request request => api.CreatePredictionAsync(request, cancellationToken),

            string requestAsString => api.CreatePredictionAsync(requestAsString, cancellationToken),

            _ => api.CreatePredictionAsync(requestAsObject, cancellationToken)
        };

        var createPredictionResponse = await createPredictionAsync.ConfigureAwait(false);

        return await CallAsync(
            timeoutInSeconds,
            async ct => await api.GetPredictionAsync(createPredictionResponse.Id, ct).ConfigureAwait(false),
            result => RunningStates.Any(s => string.Equals(s, result.Status, StringComparison.OrdinalIgnoreCase)),
            cancellationToken
        );
    }

    private static async Task<T> CallAsync<T>(
        int timeoutInSeconds,
        Func<CancellationToken, Task<T>> checkAsync,
        Func<T, bool> keepRunning,
        CancellationToken cancellationToken)
    {
        var timeoutCancellationSource = new CancellationTokenSource();
        timeoutCancellationSource.CancelAfter(timeoutInSeconds * 1000);

        var cancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCancellationSource.Token);
        
        var response = await checkAsync(cancellation.Token).ConfigureAwait(false);
        
        while (keepRunning(response))
        {
            await Task.Delay(TimeSpan.FromSeconds(WaitTimeInSeconds), cancellation.Token).ConfigureAwait(false);

            response = await checkAsync(cancellation.Token).ConfigureAwait(false);
        }

        return response;
    }
}