ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

string name = ConsoleHelper.ReadLineFromConsole("Пожалуйста, введите своё имя") ?? "";
string surname = ConsoleHelper.ReadLineFromConsole("Пожалуйста, введите свою фамилию") ?? "";

ConsoleHelper.PrintLine($"Ваше имя: {name}");
ConsoleHelper.PrintLine($"Ваша фамилия: {surname}");
ConsoleHelper.PrintLine($"Добро пожаловать, {name} {surname}!");

ConsoleHelper.PrintFooter("Благодарим за использование! Нажмите любую кнопку для выхода...");
