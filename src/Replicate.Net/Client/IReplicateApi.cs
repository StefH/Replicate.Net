using System.Threading;
using System.Threading.Tasks;
using Replicate.Net.Constants;
using Replicate.Net.Predictions;
using RestEase;

namespace Replicate.Net.Client;

[Header(HeaderKey.Accept, HeaderValue.ApplicationJson)]
[Header(HeaderKey.ContentType, HeaderValue.ApplicationJson)]
[Header(HeaderKey.UserAgent, HeaderValue.UserAgent)]
public interface IReplicateApi
{
    [Header("Authorization", Format = "Token {0}")]
    string? Token { get; set; }

    [Post("predictions/{predictionId}/cancel")]
    Task<Result> CancelPredictionAsync([Path] string predictionId, CancellationToken cancellationToken = default);

    [Post("predictions")]
    Task<Result> CreatePredictionAsync([Body] Request request, CancellationToken cancellationToken = default);

    [Post("predictions")]
    Task<Result> CreatePredictionAsync([Body] string request, CancellationToken cancellationToken = default);

    [Post("predictions")]
    Task<Result> CreatePredictionAsync([Body] object request, CancellationToken cancellationToken = default);

    [Get("predictions/{predictionId}")]
    Task<Result> GetPredictionAsync([Path] string predictionId, CancellationToken cancellationToken = default);

    [Get("predictions")]
    Task<Predictions.Predictions> GetPredictionsAsync(CancellationToken cancellationToken = default);
}