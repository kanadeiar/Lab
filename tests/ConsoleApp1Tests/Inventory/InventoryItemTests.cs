using ConsoleApp1.Inventory;
using Kanadeiar.Common.Tests;

namespace ConsoleApp1Tests.Inventory;

public class InventoryItemTests
{
    [Theory(DisplayName = "Тестирование создания нового предмета")]
    [InlineAutoData(1, "test", 1)]
    public void TestCreateNewInventory(int id, string name, int quantity)
    {
        var actual = new InventoryItem(id, name, quantity);
        var entry = actual.Entry();
        entry.Id.Should().Be(id);
        entry.Name.Should().Be(name);
        entry.Quantity.Should().Be(quantity);
    }
}
