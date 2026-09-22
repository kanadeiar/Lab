using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels;

public class MainWindowViewModel : Base.ViewModelBase
{
    private string? _filePath;

    /// <summary>
    /// Заголовок окна
    /// </summary>
    public string Title
    {
        get => field;
        set => Set(ref field, value);
    } = "Опытно-экспериментальное приложение";

    /// <summary>
    /// Текст содержимого редактируемого файла
    /// </summary>
    public string Text
    {
        get => field;
        set => Set(ref field, value);
    } = string.Empty;

    // ============================================================
    // Команды работы с файлами
    // ============================================================

    /// <summary>
    /// Создать новый файл
    /// </summary>
    public ICommand NewFileCommand => field ??=
        new LambdaCommand(OnNewFileCommandExecuted, CanNewFileCommandExecute);
    private bool CanNewFileCommandExecute(object? p) => true;
    private void OnNewFileCommandExecuted(object? p)
    {
        _filePath = null;
        Text = string.Empty;
        UpdateTitle();
    }

    /// <summary>
    /// Открыть файл
    /// </summary>
    public ICommand OpenFileCommand => field ??=
        new LambdaCommand(OnOpenFileCommandExecuted, CanOpenFileCommandExecute);
    private bool CanOpenFileCommandExecute(object? p) => true;
    private void OnOpenFileCommandExecuted(object? p)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
            Title = "Открыть файл"
        };
        if (dialog.ShowDialog() != true) return;

        _filePath = dialog.FileName;
        Text = File.ReadAllText(_filePath);
        UpdateTitle();
    }

    /// <summary>
    /// Сохранить файл (если путь известен — сохраняет, иначе — диалог)
    /// </summary>
    public ICommand SaveFileCommand => field ??=
        new LambdaCommand(OnSaveFileCommandExecuted, CanSaveFileCommandExecute);
    private bool CanSaveFileCommandExecute(object? p) => true;
    private void OnSaveFileCommandExecuted(object? p)
    {
        if (_filePath is not null)
        {
            File.WriteAllText(_filePath, Text);
            return;
        }

        OnSaveAsFileCommandExecuted(p);
    }

    /// <summary>
    /// Сохранить файл с новым именем / в новом месте
    /// </summary>
    public ICommand SaveAsFileCommand => field ??=
        new LambdaCommand(OnSaveAsFileCommandExecuted, CanSaveAsFileCommandExecute);
    private bool CanSaveAsFileCommandExecute(object? p) => true;
    private void OnSaveAsFileCommandExecuted(object? p)
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
            Title = "Сохранить файл как",
            FileName = Path.GetFileName(_filePath) ?? "Новый файл.txt"
        };
        if (dialog.ShowDialog() != true) return;

        _filePath = dialog.FileName;
        File.WriteAllText(_filePath, Text);
        UpdateTitle();
    }

    // ============================================================
    // Прочие команды
    // ============================================================

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

    // ============================================================
    // Вспомогательные методы
    // ============================================================

    private void UpdateTitle()
    {
        Title = _filePath is null
            ? "Безымянный — Опытно-экспериментальное приложение"
            : $"{Path.GetFileName(_filePath)} — Опытно-экспериментальное приложение";
    }
}
