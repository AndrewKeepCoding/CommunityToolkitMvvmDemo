namespace CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate.Commands;

public interface IRelayCommand<in T> : IRelayCommand
{
    bool CanExecute(T? parameter);

    void Execute(T parameter);
}
