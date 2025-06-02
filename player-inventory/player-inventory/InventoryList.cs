namespace player_inventory;

public class InventoryList
{
    private static readonly List<InventoryItem> Items = new List<InventoryItem>();

    /// <summary>
    /// Option 1
    /// </summary>
    public void AddItem(InventoryItem item)
    {
        Items.Add(item);
    }

    /// <summary>
    /// Option 2
    /// </summary>
    public void RemoveItemAt(int index)
    {
        Items.RemoveAt(index);
    }

    /// <summary>
    /// Option 3
    /// </summary>
    public void Display()
    {
        Console.WriteLine("Inventory Items:");
        int count = 0;
        foreach (var item in Items)
        {
            Console.WriteLine($"{count} - {item.Name} ({item.Type})");
            count++;
        }
    }
}

