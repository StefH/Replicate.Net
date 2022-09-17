using System;
using Newtonsoft.Json;

namespace Replicate.Net.Models;

public class Model
{
    public Uri Url { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Visibility { get; set; } = null!;

    [JsonProperty("github_url")]
    public Uri GithubUrl { get; set; } = null!;

    [JsonProperty("paper_url")]
    public Uri PaperUrl { get; set; } = null!;

    [JsonProperty("license_url")]
    public Uri LicenseUrl { get; set; } = null!;

    [JsonProperty("latest_version")]
    public ModelVersion LatestVersion { get; set; } = null!;
}