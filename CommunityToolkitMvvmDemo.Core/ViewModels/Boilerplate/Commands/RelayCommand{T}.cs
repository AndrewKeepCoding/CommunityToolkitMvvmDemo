namespace CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate.Commands;

public class RelayCommand<T>(Action<T?> execute, Predicate<T?> canExecute) : IRelayCommand<T>
{
    private readonly Action<T?> _execute = execute;

    private readonly Predicate<T?>? _canExecute = canExecute;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(T? parameter) => _canExecute?.Invoke(parameter) is not false;

    public bool CanExecute(object? parameter) => CanExecute((T?)parameter);

    public void Execute(T? parameter) => _execute(parameter);

    public void Execute(object? parameter) => Execute((T?)parameter);

    public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
