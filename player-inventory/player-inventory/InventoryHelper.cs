namespace player_inventory;

public class InventoryHelper
{
    public event EventHandler OnItemAdded;
    public event EventHandler OnItemRemoved;
    public event EventHandler OnItemsViewed;

    List<char> AcceptedKeys = new List<char>
    {
        '1', '2', '3', '4'
    };

    public void DisplayMenu()
    {
        Console.WriteLine("Player Inventory System");
        Console.WriteLine("1. Add Item");
        Console.WriteLine("2. Remove Item");
        Console.WriteLine("3. View Inventory");
        Console.WriteLine("4. Exit");
    }

    public bool CanAcceptKey(char key)
    {
        return AcceptedKeys.Contains(key);
    }

    public Result HandleInput(char key)
    {
        Result result = new Result()
        {
            Handled = true
        };

        var inventoryList = new InventoryList();

        switch (key)
        {
            case '1':
                if (OnItemAdded != null)
                {
                    OnItemAdded(this, EventArgs.Empty);
                }

                inventoryList.AddItem(new InventoryItem()
                {
                    Name = "Sword",
                    Type = "Weapon"
                });
                return result;
            case '2':
                Console.WriteLine("\nWhich item to remove? escape to cancel");
                inventoryList.Display();

                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.Escape)
                {
                    result.Handled = false;
                    return result;
                }

                if (OnItemRemoved != null)
                {
                    OnItemRemoved(this, EventArgs.Empty);
                }

                inventoryList.RemoveItemAt(int.Parse(input.KeyChar.ToString()));
                return result;
            case '3':
                if (OnItemsViewed != null)
                {
                    OnItemsViewed(this, EventArgs.Empty);
                }

                inventoryList.Display();
                return result;
            case '4':
                Console.WriteLine("\nExiting...");
                result.ShouldExit = true;
                return result;
            default:
                return new Result()
                {
                    Handled = false
                };
        }
    }
}