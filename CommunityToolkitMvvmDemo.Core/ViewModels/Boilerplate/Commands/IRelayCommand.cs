using System.Windows.Input;

namespace CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate.Commands;

public interface IRelayCommand : ICommand
{
    void NotifyCanExecuteChanged();
}
