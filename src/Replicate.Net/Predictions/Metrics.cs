using Newtonsoft.Json;

namespace Replicate.Net.Predictions;

public class Metrics
{
    [JsonProperty("predict_time")]
    public double PredictTime { get; set; }
}