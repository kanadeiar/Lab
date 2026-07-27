using ConsoleApp1.InventoryModule;
using Kanadeiar.Common.Tests;

namespace ConsoleApp1Tests.InventoryModule;

public class InventoryTests
{
    [Theory(DisplayName = "Тестирование создания нового предмета")]
    [InlineAutoMoqData("test", 1)]
    public void TestCreateNewInventory(string name, int quantity)
    {
        var sut = new Inventory(name, quantity);

        sut.Name.Should().Be(name);
        sut.Quantity.Should().Be(quantity);
    }

    [Theory(DisplayName = "Проверка того, что можно переименовать любой предмет на складе")]
    [AutoMoqData]
    public void TestRename(Inventory item)
    {
        var expected = "Новое имя";

        var sut = item.Rename(expected);

        sut.Name.Should().Be(expected);
    }

    [Theory(DisplayName = "Проверка того, что можно изменить количество элементов любого предмета на складе")]
    [AutoMoqData]
    public void TestQuantity(Inventory item)
    {
        var expected = 44;

        var sut = item.SetQuantity(expected);

        sut.Quantity.Should().Be(expected);
    }
}
