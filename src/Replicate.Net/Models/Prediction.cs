using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Replicate.Net.Models;

public class Prediction
{
    public string Id { get; set; } = null!;

    public string Version { get; set; } = null!;

    public PredictionUrls Urls { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// starting: the prediction is starting up.If this status lasts longer than a few seconds, then it's typically because a new worker is being started to run the prediction.
    /// processing: the predict() method of the model is currently running.
    /// succeeded: the prediction completed successfully.
    /// failed: the prediction encountered an error during processing.
    /// canceled: the prediction was canceled by the user.
    /// </summary>
    public string Status { get; set; } = null!;

    public object? Input { get; set; } = null!;

    public object? Output { get; set; }

    [JsonIgnore]
    public string[]? GeneratedPictures
    {
        get
        {
            switch (Output)
            {
                case JArray pictures:
                    return pictures.Values<string>().Where(p => p != null).Select(p => p!).ToArray();
                case string picture:
                    return new[] { picture };
                default:
                    return null;
            }
        }
    }

    public object? Error { get; set; }

    public string? Logs { get; set; }

    public PredictionMetrics Metrics { get; set; } = null!;
}