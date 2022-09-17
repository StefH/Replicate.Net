using System.Collections.Generic;

namespace Replicate.Net.Models;

public class PagedResult<T>
{
    public string? Next { get; set; }

    public string? Previous { get; set; }

    public IReadOnlyList<T>? Results { get; set; }
}