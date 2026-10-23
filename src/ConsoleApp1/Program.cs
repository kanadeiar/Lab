ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

string name = ConsoleHelper.ReadLineFromConsole("Пожалуйста, введите своё имя") ?? "";
string surname = ConsoleHelper.ReadLineFromConsole("Пожалуйста, введите свою фамилию") ?? "";
var age = ConsoleHelper.ReadNumberFromConsole<int>("Пожалуйста, введите ваш возраст");

ConsoleHelper.PrintLine($"Ваше имя: {name}");
ConsoleHelper.PrintLine($"Ваша фамилия: {surname}");
ConsoleHelper.PrintLine($"Ваш возраст: {age}");
ConsoleHelper.PrintLine($"Добро пожаловать, {name} {surname}!");

ConsoleHelper.PrintFooter("Благодарим за использование! Нажмите любую кнопку для выхода...");
