using CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate;
using Microsoft.UI.Xaml.Controls;

namespace CommunityToolkitMvvmDemo.Views;

public sealed partial class MvvmSamplePage : Page
{
    public MvvmSamplePage()
    {
        this.InitializeComponent();
    }

    private SampleViewModel ViewModel { get; } = new();
}
