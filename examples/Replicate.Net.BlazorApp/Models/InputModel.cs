using System.ComponentModel.DataAnnotations;

namespace Replicate.Net.BlazorApp.Models;

public class InputModel
{
    [Required]
    [StringLength(1500, ErrorMessage = "Prompt is too long.")]
    public string? Prompt { get; set; }
}