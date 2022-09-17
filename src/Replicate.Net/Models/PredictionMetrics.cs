using Newtonsoft.Json;

namespace Replicate.Net.Models;

public class PredictionMetrics
{
    [JsonProperty("predict_time")]
    public double PredictTime { get; set; }
}