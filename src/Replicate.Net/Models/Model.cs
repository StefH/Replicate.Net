using System;

namespace Replicate.Net.Models;

public class Model
{
    public Uri Url { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Visibility { get; set; } = null!;

    public Uri? GithubUrl { get; set; }

    public Uri? PaperUrl { get; set; }

    public Uri? LicenseUrl { get; set; }

    public ModelVersion LatestVersion { get; set; } = null!;

    public int? RunCount { get; set; }

    public Uri? CoverImageUrl { get; set; }

    public Prediction? DefaultExample { get; set; } = null!;
}