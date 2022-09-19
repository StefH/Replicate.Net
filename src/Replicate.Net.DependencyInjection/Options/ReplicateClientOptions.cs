using System;
using System.ComponentModel.DataAnnotations;
using Replicate.Net.Factory;

namespace Replicate.Net.DependencyInjection.Options;

public class ReplicateClientOptions
{
    [Required] 
    public Uri BaseUrl { get; set; } = ReplicateApiFactory.PredictionBaseUrl;

    public string? Token { get; set; }
}