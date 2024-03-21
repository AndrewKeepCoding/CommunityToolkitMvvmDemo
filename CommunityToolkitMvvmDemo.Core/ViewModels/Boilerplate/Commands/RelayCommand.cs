namespace CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate.Commands;

public class RelayCommand(Action execute, Func<bool> canExecute) : IRelayCommand
{
    private readonly Action _execute = execute;

    private readonly Func<bool> _canExecute = canExecute;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => _canExecute();

    public void Execute(object? parameter) => _execute();

    public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
