using System;

namespace Replicate.Net.Models;

public class Model
{
    public Uri Url { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Visibility { get; set; } = null!;

    public Uri? GithubUrl { get; set; } = null!;

    public Uri? PaperUrl { get; set; } = null!;

    public Uri? LicenseUrl { get; set; } = null!;

    public ModelVersion LatestVersion { get; set; } = null!;

    public int? RunCount { get; set; } = null!;

    public Uri? CoverImageUrl { get; set; } = null!;

    public Prediction? DefaultExample { get; set; } = null!;

}
