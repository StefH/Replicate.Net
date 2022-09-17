using Newtonsoft.Json;

namespace Replicate.Net.Models;

public class Request
{
    /// <summary>
    /// The ID of the model version that you want to run.
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; } = null!;

    /// <summary>
    /// The model's input.
    /// </summary>
    [JsonProperty("input")]
    public PredictionInput Input { get; set; } = null!;
}