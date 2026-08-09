using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels;

public class MainWindowViewModel : Base.ViewModelBase
{
    public string Title
    {
        get;
        init => Set(ref field, value);
    } = "Опытный текстовый редактор";

    public string Text
    {
        get;
        set => Set(ref field, value);
    } = string.Empty;

    public ICommand NewFileCommand => field ??=
    new LambdaCommand(OnNewFileCommandExecuted);
    private void OnNewFileCommandExecuted(object? p)
    {
        Text = string.Empty;
    }

    public ICommand OpenFileCommand => field ??=
        new LambdaCommand(OnOpenFileCommandExecuted);
    private void OnOpenFileCommandExecuted(object? p)
    {
        var dialog = new OpenFileDialog();
        var result = dialog.ShowDialog();
        if (result == true) 
        {
            if (File.Exists(dialog.FileName)) 
            {
                var text = File.ReadAllText(dialog.FileName);
                Text = text;
            }
        }
    }

    public ICommand SaveFileCommand => field ??=
    new LambdaCommand(OnSaveFileCommandExecuted);
    private void OnSaveFileCommandExecuted(object? p)
    {
        var dialog = new SaveFileDialog();
        var result = dialog.ShowDialog();
        if (result == true)
        {
            var text = Text;
            File.WriteAllText(dialog.FileName, text);
        }
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
