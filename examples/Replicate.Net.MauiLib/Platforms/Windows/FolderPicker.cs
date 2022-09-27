using WindowsFolderPicker = Windows.Storage.Pickers.FolderPicker;
using PickerLocationId = Windows.Storage.Pickers.PickerLocationId;

namespace Replicate.Net.MauiLib.Platforms.Windows;

/// <summary>
/// https://github.com/jfversluis/MauiFolderPickerSample
/// https://learn.microsoft.com/en-us/windows/uwp/files/quickstart-using-file-and-folder-pickers
/// </summary>
public class FolderPicker : IFolderPicker
{
    private string? _lastSelected;

    public async Task<string> PickFolderAsync()
    {
        var folderPicker = new WindowsFolderPicker();

        //if (!string.IsNullOrEmpty(_lastSelected))
        //{
        //    folderPicker.SuggestedStartLocation = new PickerLocationId(_lastSelected);
        //}

        // Needed to make it work on Windows 10
        folderPicker.FileTypeFilter.Add("*");

        // Get the current window's HWND by passing in the Window object
        var hwnd = ((MauiWinUIWindow)Application.Current!.Windows[0].Handler.PlatformView!).WindowHandle;

        // Associate the HWND with the file picker
        WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

        var result = await folderPicker.PickSingleFolderAsync();

        _lastSelected = result.Path;

        return _lastSelected;
    }
}