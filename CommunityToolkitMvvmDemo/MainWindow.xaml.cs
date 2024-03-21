using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace CommunityToolkitMvvmDemo;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
    }

    private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (sender.SelectedItem is not NavigationViewItem selectedItem ||
            selectedItem.Tag is not string selectedItemTag ||
            Type.GetType(selectedItemTag) is not Type destinationPageType)
        {
            return;
        }

        _ = this.ContentFrame.Navigate(destinationPageType);
    }
}
