ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

var name = ConsoleHelper.ReadLineFromConsole("Пожалуйста, свое имя") ?? "";

ConsoleHelper.PrintLine($"Ваше имя: {name}");

ConsoleHelper.PrintFooter("Благодарим за использование! Нажмите любую кнопку для выхода...");
