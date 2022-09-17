using System;
using Newtonsoft.Json;

namespace Replicate.Net.Models;

public class ModelVersion
{
    public string Id { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string CogVersion { get; set; } = null!;

    [JsonProperty("openapi_schema")]
    public object OpenApiSchema { get; set; } = null!;
}