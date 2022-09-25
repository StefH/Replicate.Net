using RestEase;
using System.Threading.Tasks;
using System.Threading;
using Replicate.Net.Models;

namespace Replicate.Net.Client
{
    public interface IInPainterApi
    {
        [Post("predictions/{predictionId}/cancel")]
        Task<Prediction> CancelPredictionAsync([Path] string predictionId, CancellationToken cancellationToken = default);

        [Post("predictions")]
        Task<Prediction> CreatePredictionAsync([Body] PredictionInput input, CancellationToken cancellationToken = default);

        [Post("predictions")]
        Task<Prediction> CreatePredictionAsync([Body] string input, CancellationToken cancellationToken = default);

        [Post("predictions")]
        Task<Prediction> CreatePredictionAsync([Body] object input, CancellationToken cancellationToken = default);

        [Get("predictions/{predictionId}")]
        Task<Prediction> GetPredictionAsync([Path] string predictionId, CancellationToken cancellationToken = default);
    }
}