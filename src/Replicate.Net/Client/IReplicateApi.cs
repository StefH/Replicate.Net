using System.Threading;
using System.Threading.Tasks;
using Replicate.Net.Constants;
using Replicate.Net.Models;
using RestEase;

namespace Replicate.Net.Client;

[Header(HeaderKey.Accept, HeaderValue.ApplicationJson)]
[Header(HeaderKey.ContentType, HeaderValue.ApplicationJson)]
[Header(HeaderKey.UserAgent, HeaderValue.UserAgent)]
public interface IReplicateApi
{
    #region predictions

    [Post("predictions/{predictionId}/cancel")]
    Task<Prediction> CancelPredictionAsync([Path] string predictionId, CancellationToken cancellationToken = default);

    [Post("predictions")]
    Task<Prediction> CreatePredictionAsync([Body] Request request, CancellationToken cancellationToken = default);

    [Post("predictions")]
    Task<Prediction> CreatePredictionAsync([Body] string request, CancellationToken cancellationToken = default);

    [Post("predictions")]
    Task<Prediction> CreatePredictionAsync([Body] object request, CancellationToken cancellationToken = default);

    [Get("predictions/{predictionId}")]
    Task<Prediction> GetPredictionAsync([Path] string predictionId, CancellationToken cancellationToken = default);

    [Get("predictions")]
    Task<PagedResult<Prediction>> GetPredictionsAsync(CancellationToken cancellationToken = default);

    [Get("predictions")]
    Task<PagedResult<Prediction>> GetPredictionsAsync([Query] string cursor, CancellationToken cancellationToken = default);

    [Get("{url}")]
    Task<PagedResult<Prediction>> GetPredictionsByUrlAsync([Path(UrlEncode = false)] string url, CancellationToken cancellationToken = default);

    #endregion predictions

    #region models

    [Get("models/{owner}/{name}")]
    Task<Model> GetModelAsync([Path] string owner, [Path] string name, CancellationToken cancellationToken = default);

    [Get("models/{owner}/{name}/versions")]
    Task<PagedResult<ModelVersion>> GetModelVersionsAsync([Path] string owner, [Path] string name, CancellationToken cancellationToken = default);

    [Get("models/{owner}/{name}/version/{id}")]
    Task<PagedResult<ModelVersion>> GetModelVersionAsync([Path] string owner, [Path] string name, [Path] string id, CancellationToken cancellationToken = default);

    [Get("{url}")]
    Task<PagedResult<ModelVersion>> GetModelVersionsByUrlAsync([Path(UrlEncode = false)] string url, CancellationToken cancellationToken = default);

    #endregion models

    #region collections

    [Get("collections/{collectionSlug}")]
    Task<Collections> GetCollectionsAsync([Path] string collectionSlug, CancellationToken cancellationToken = default);

    #endregion collections
}