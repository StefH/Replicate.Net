﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Replicate.Net.Models.Predictions;
using Stef.Validation;

namespace Replicate.Net.Client;

public static class PredictionsApiExtensions
{
    private const int WaitTimeInSeconds = 3;
    private static readonly string[] States = { "starting", "processing" };

    public static async Task<Result> CreatePredictionAndWaitOnResultAsync(this IPredictionsApi api, object requestAsObject, int timeoutInSeconds = 60, CancellationToken cancellationToken = default)
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
            async () => await api.GetPredictionAsync(createPredictionResponse.Id, cancellationToken).ConfigureAwait(false),
            result => States.Any(s => string.Equals(s, result.Status, StringComparison.OrdinalIgnoreCase)),
            cancellationToken
        );
    }

    private static async Task<T> CallAsync<T>(
        int timeoutInSeconds,
        Func<Task<T>> checkFunc,
        Func<T, bool> keepRunningFunc,
        CancellationToken cancellationToken)
    {
        var response = await checkFunc().ConfigureAwait(false);
        var retry = 0;
        while (keepRunningFunc(response) && retry < timeoutInSeconds / WaitTimeInSeconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(WaitTimeInSeconds), cancellationToken).ConfigureAwait(false);

            response = await checkFunc().ConfigureAwait(false);
        }

        return response;
    }
}