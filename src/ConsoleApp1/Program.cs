using ConsoleApp1.InventoryModule;

ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

var name = ConsoleHelper.ReadLineFromConsole("Введите название") ?? "";
var count = ConsoleHelper.ReadNumberFromConsole<int>("Введите количество");

var inventory = new Inventory(name, count);

ConsoleHelper.PrintLine($"Название и количество: {inventory}");
ConsoleHelper.Pause();

var updated = inventory.Rename("name").SetQuantity(1);

ConsoleHelper.PrintLine($"Обновлено: {updated}");

ConsoleHelper.PrintFooter();
