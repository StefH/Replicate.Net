using System.Threading;
using System.Threading.Tasks;
using Replicate.Net.Interfaces;
using Replicate.Net.Models;
using RestEase;

namespace Replicate.Net.Common.Example.Client;

public interface IExampleApi
{
    [Post("predictions/{predictionId}/cancel")]
    Task<Prediction> CancelPredictionAsync([Path] string predictionId, CancellationToken cancellationToken = default);

    [Post("predictions")]
    Task<Prediction> CreatePredictionAsync([Body] IPredictionInput input, CancellationToken cancellationToken = default);

    [Get("predictions/{predictionId}")]
    Task<Prediction> GetPredictionAsync([Path] string predictionId, CancellationToken cancellationToken = default);
}