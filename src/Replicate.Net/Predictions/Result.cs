using System;
using AnyOfTypes;
using Newtonsoft.Json;

namespace Replicate.Net.Predictions;

public class Result
{
    public string Id { get; set; } = null!;

    public string Version { get; set; } = null!;

    public Urls Urls { get; set; } = null!;

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("completed_at")]
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// starting: the prediction is starting up.If this status lasts longer than a few seconds, then it's typically because a new worker is being started to run the prediction.
    /// processing: the predict() method of the model is currently running.
    /// succeeded: the prediction completed successfully.
    /// failed: the prediction encountered an error during processing.
    /// canceled: the prediction was canceled by the user.
    /// </summary>
    public string Status { get; set; } = null!;

    public Input Input { get; set; } = null!;

    public AnyOf<string, string[]>? Output { get; set; }

    //public object? Output { get; set; } // string or string[]

    public object? Error { get; set; }

    public string? Logs { get; set; }

    public Metrics Metrics { get; set; } = null!;
}