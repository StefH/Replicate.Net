using System.Collections.Generic;

namespace Replicate.Net.Models;

public class Collections
{
    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Description { get; set; } = null!;

    public IReadOnlyList<Model> Models { get; set; } = null!;
}
