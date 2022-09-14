namespace Replicate.Net.Settings;

public record ClientSettings
{
    public string? Url { get; init; }

    public string? Token { get; init; }
}
