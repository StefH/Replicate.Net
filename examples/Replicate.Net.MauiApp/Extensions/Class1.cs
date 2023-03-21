using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace Replicate.Net.MauiApp.Extensions
{
    internal static class Class1
    {
        public static IEnumerable<T> FindChildrenOfType<T>(this DependencyObject parent) 
            where T : DependencyObject
        {
            if (parent is ContentControl contentControl)
            {
                if (contentControl.Content is T contentOfT)
                {
                    yield return contentOfT;
                }

                if (contentControl.Content is DependencyObject dependencyObjectContent)
                {
                    foreach (T grandChild in FindChildrenOfType<T>(dependencyObjectContent))
                    {
                        yield return grandChild;
                    }
                }
            }
            else
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                    if (child is T childOfT)
                    {
                        yield return childOfT;
                    }

                    foreach (T grandChild in FindChildrenOfType<T>(child))
                    {
                        yield return grandChild;
                    }
                }
            }
        }
    }
}