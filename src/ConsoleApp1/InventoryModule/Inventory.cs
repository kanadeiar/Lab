namespace ConsoleApp1.InventoryModule;

public class Inventory(string name, int quantity = 0)
{
    public string Name => name;

    public int Quantity => quantity;

    public Inventory Rename(string newName) => new(newName, quantity);

    public Inventory SetQuantity(int newQuantity) => new(name, newQuantity);

    public override string ToString() => $"{name} - {quantity} шт.";
}
