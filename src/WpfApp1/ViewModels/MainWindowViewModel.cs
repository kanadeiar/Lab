using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels;

public class MainWindowViewModel : Base.ViewModelBase
{
    public string Name
    {
        get;
        init => Set(ref field, value);
    } = string.Empty;

    public string Title
    {
        get;
        init => Set(ref field, value);
    } = "Опытное приложение";

    public ICommand HelloCommand => field ??=
        new LambdaCommand(OnHelloCommandExecuted);
    private void OnHelloCommandExecuted(object? p)
    {
        var message = $"Привет, {Name}!";
        MessageBox.Show(message, "Приветствие");
    }

    /// <summary>
    /// Закрыть приложение
    /// </summary>
    public ICommand CloseAppCommand => field ??=
        new LambdaCommand(OnCloseAppCommandExecuted);
    private void OnCloseAppCommandExecuted(object? p)
    {
        Application.Current.Shutdown();
    }

    /// <summary>
    /// Сведения о программе
    /// </summary>
    public ICommand AboutAppCommand => field ??=
        new LambdaCommand(OnAboutAppCommandExecuted);
    private void OnAboutAppCommandExecuted(object? p)
    {
        MessageBox.Show("Опытное приложение.", "О программе ...");
    }
}
