﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Replicate.Net.Constants;
using Replicate.Net.Models;
using Stef.Validation;

namespace Replicate.Net.Client
{
    public static class IInPainterApiExtensions
    {
        public static async Task<Prediction> CreatePredictionAndWaitOnResultAsync(this IInPainterApi api, object inputAsObject, int timeoutInSeconds = 5 * 60, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(api);
            Guard.NotNull(inputAsObject);

            var createPredictionAsync = inputAsObject switch
            {
                PredictionInput input => api.CreatePredictionAsync(input, cancellationToken),

                string inputAsString => api.CreatePredictionAsync(inputAsString, cancellationToken),

                _ => api.CreatePredictionAsync(inputAsObject, cancellationToken)
            };

            var createPredictionResponse = await createPredictionAsync.ConfigureAwait(false);

            return await IReplicateApiExtensions.CallAsync(
                timeoutInSeconds,
                async ct => await api.GetPredictionAsync(createPredictionResponse.Id, ct).ConfigureAwait(false),
                async ct => await api.CancelPredictionAsync(createPredictionResponse.Id, ct).ConfigureAwait(false),
                result => ReplicateConstants.RunningStates.Any(s => string.Equals(s, result.Status, StringComparison.OrdinalIgnoreCase)),
                cancellationToken
            );
        }
    }
}