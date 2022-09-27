namespace Replicate.Net.MauiLib;

public interface IFolderPicker
{
    Task<string> PickFolderAsync();
}