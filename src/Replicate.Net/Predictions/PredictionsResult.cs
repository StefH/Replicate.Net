using System.Collections.Generic;

namespace Replicate.Net.Predictions;

public class PredictionsResult
{
    public string? Next { get; set; }

    public string? Previous { get; set; }

    public IReadOnlyList<Result>? Results { get; set; }
}