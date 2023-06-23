using Replicate.Net.Interop;

namespace Replicate.Net.Models;

public class Request
{
    /// <summary>
    /// The ID of the model version that you want to run.
    /// </summary>
    public string Version { get; set; } = null!;

    /// <summary>
    /// The model's input.
    /// </summary>
    public IPredictionInput Input { get; set; } = null!;
}