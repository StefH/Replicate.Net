using WindowsFolderPicker = Windows.Storage.Pickers.FolderPicker;

namespace Replicate.Net.MauiLib.Platforms.Windows;

/// <summary>
/// https://github.com/jfversluis/MauiFolderPickerSample
/// </summary>
public class FolderPicker : IFolderPicker
{
    public async Task<string> PickFolderAsync()
    {
        var folderPicker = new WindowsFolderPicker();

        // Might be needed to make it work on Windows 10
        folderPicker.FileTypeFilter.Add("*.*");

        // Get the current window's HWND by passing in the Window object
        var hwnd = ((MauiWinUIWindow)Application.Current!.Windows[0].Handler.PlatformView!).WindowHandle;

        // Associate the HWND with the file picker
        WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

        var result = await folderPicker.PickSingleFolderAsync();

        return result?.Path;
    }
}