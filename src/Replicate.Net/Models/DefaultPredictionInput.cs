﻿using Newtonsoft.Json;
using Replicate.Net.Interfaces;

namespace Replicate.Net.Models;

/// <summary>
/// The default model's input.
/// </summary>
public class DefaultPredictionInput : IPredictionInput
{
    /// <summary>
    /// Input prompt.
    /// </summary>
    public string Prompt { get; set; } = null!;

    /// <summary>
    /// Negative prompt
    /// </summary>
    public string NegativePrompt { get; set; } = null!;

    /// <summary>
    /// Width of output image. Maximum size is 1024x768 or 768x1024 because of memory limits. Valid values are 128, 256, 512, 768 and 1024.
    /// </summary>
    public int Width { get; set; } = 512;

    /// <summary>
    /// Height of output image. Maximum size is 1024x768 or 768x1024 because of memory limits. Valid values are 128, 256, 512, 768 and 1024.
    /// </summary>
    public int Height { get; set; } = 512;

    /// <summary>
    /// Initial image (URL) to generate variations of. Will be resized to the specified width and height.
    /// 
    /// This image should be uploaded to a publicly accessible HTTP URL and that URL string should be used for this property.
    /// </summary>
    public string? InitImage { get; set; }

    /// <summary>
    /// Black and white image to use as mask for inpainting over init_image.
    /// Black pixels are inpainted and white pixels are preserved. Experimental feature, tends to work better with prompt strength of 0.5-0.7
    ///
    /// This image should be uploaded to a publicly accessible HTTP URL and that URL string should be used for this property.
    /// </summary>
    public string? Mask { get; set; }

    /// <summary>
    /// Prompt strength when using init image. 1.0 corresponds to full destruction of information in init image.
    /// </summary>
    public double PromptStrength { get; set; } = 0.8;

    /// <summary>
    /// Number of images to output. Default 4. Valid values are 1 and 4.
    /// </summary>
    [JsonProperty("num_outputs")]
    public int NumberOfOutputs { get; set; } = 4;

    /// <summary>
    /// Number of denoising steps.
    /// </summary>
    [JsonProperty("num_inference_steps")]
    public int NumberOfInferenceSteps { get; set; } = 50;

    /// <summary>
    /// Scale for classifier-free guidance. (minimum: 1; maximum: 500)
    /// </summary>
    public double GuidanceScale { get; set; } = 7.5;

    /// <summary>
    /// Random seed. Leave blank to randomize the seed.
    /// </summary>
    public int? Seed { get; set; }
}