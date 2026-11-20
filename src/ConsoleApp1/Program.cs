ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

string name = ConsoleHelper.ReadLineFromConsole("Пожалуйста, введите своё имя") ?? "";

ConsoleHelper.PrintLine($"Ваше имя: {name}");

ConsoleHelper.PrintFooter("Благодарим за использование! Нажмите любую кнопку для выхода...");

