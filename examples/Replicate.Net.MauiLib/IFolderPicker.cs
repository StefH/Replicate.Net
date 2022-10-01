namespace Replicate.Net.MauiLib;

/// <summary>
/// https://github.com/jfversluis/MauiFolderPickerSample
/// </summary>
public interface IFolderPicker
{
    Task<string> PickFolderAsync();
}