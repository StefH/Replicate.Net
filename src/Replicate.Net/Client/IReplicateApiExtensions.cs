using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Replicate.Net.Models;
using Stef.Validation;

namespace Replicate.Net.Client;

// ReSharper disable once InconsistentNaming
public static class IReplicateApiExtensions
{
    private const int WaitTimeInSeconds = 3;
    private static readonly string[] RunningStates = { "starting", "processing" };

    public static async Task<Prediction> CreatePredictionAndWaitOnResultAsync(this IReplicateApi api, object requestAsObject, int timeoutInSeconds = 5 * 60, CancellationToken cancellationToken = default)
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
            async ct => await api.CancelPredictionAsync(createPredictionResponse.Id, ct).ConfigureAwait(false),
            result => RunningStates.Any(s => string.Equals(s, result.Status, StringComparison.OrdinalIgnoreCase)),
            cancellationToken
        );
    }

    public static async Task<IReadOnlyList<Prediction>?> GetAllPredictionsAsync(this IReplicateApi api, CancellationToken cancellationToken = default)
    {
        Guard.NotNull(api);

        return await PageAsync
        (
            async () => await api.GetPredictionsAsync(cancellationToken).ConfigureAwait(false),
            async url => await api.GetPredictionsByUrlAsync(url, cancellationToken).ConfigureAwait(false)
        );
    }

    public static async Task<IReadOnlyList<ModelVersion>?> GetAllModelVersionsAsync(this IReplicateApi api, string owner, string name, CancellationToken cancellationToken = default)
    {
        Guard.NotNull(api);

        return await PageAsync
        (
            async () => await api.GetModelVersionsAsync(owner, name, cancellationToken).ConfigureAwait(false),
            async url => await api.GetModelVersionsByUrlAsync(url, cancellationToken).ConfigureAwait(false)
        );
    }

    private static async Task<IReadOnlyList<T>?> PageAsync<T>(Func<Task<PagedResult<T>>> getAsync, Func<string, Task<PagedResult<T>>> nextAsync)
    {
        var predictionsResult = await getAsync().ConfigureAwait(false);
        if (predictionsResult.Results is null)
        {
            return null;
        }

        var results = predictionsResult.Results.ToList();
        while (predictionsResult.Next is not null)
        {
            predictionsResult = await nextAsync(predictionsResult.Next).ConfigureAwait(false);
            if (predictionsResult.Results is null)
            {
                break;
            }

            results.AddRange(predictionsResult.Results);
        }

        return results;
    }

    private static async Task<T> CallAsync<T>(
        int timeoutInSeconds,
        Func<CancellationToken, Task<T>> checkAsync,
        Func<CancellationToken, Task<T>> cancelAsync,
        Func<T, bool> keepRunning,
        CancellationToken cancellationToken)
    {
        var timeoutCancellationSource = new CancellationTokenSource();
        timeoutCancellationSource.CancelAfter(timeoutInSeconds * 1000);

        try
        {
            var cancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCancellationSource.Token);

            var response = await checkAsync(cancellation.Token).ConfigureAwait(false);

            while (keepRunning(response))
            {
                await Task.Delay(TimeSpan.FromSeconds(WaitTimeInSeconds), cancellation.Token).ConfigureAwait(false);

                response = await checkAsync(cancellation.Token).ConfigureAwait(false);
            }

            return response;
        }
        catch (TaskCanceledException)
        {
            // In case TaskCanceledException is thrown, try to cancel the prediction to save resources/money.
            try
            {
                timeoutCancellationSource = new CancellationTokenSource();
                timeoutCancellationSource.CancelAfter(1000);
                await cancelAsync(timeoutCancellationSource.Token);
            }
            catch
            {
                // Ignore
            }

            throw;
        }
    }
}