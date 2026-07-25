using ConsoleApp1.Contracts;

namespace ConsoleApp1.Inventory;

public class InventoryItem(int id, string name, int quantity = 0)
{
    public InventoryEntry Entry()
    {
        return new InventoryEntry
        {
            Id = id,
            Name = name,
            Quantity = quantity
        };
    }

    public override string ToString() => $"{name} - {quantity} шт.";
}
