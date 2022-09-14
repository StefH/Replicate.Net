using System.Collections.Generic;

namespace Replicate.Net.Models.Predictions;

public class Predictions
{
    public string? Next { get; set; }

    public string? Previous { get; set; }

    public IReadOnlyList<Result>? Results { get; set; }
}