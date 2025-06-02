namespace player_inventory;

class Program
{
    static void Main(string[] args)
    {
        var inventoryHelper = new InventoryHelper();
        var result = new Result();

        inventoryHelper.OnItemAdded += OnItemAdded;
        inventoryHelper.OnItemRemoved += (sender, e) => { Console.WriteLine("\nItem removed from inventory."); };
        inventoryHelper.OnItemsViewed += (sender, e) => { Console.WriteLine("\nInventory viewed."); };

        do
        {
            inventoryHelper.DisplayMenu();

            Console.Write("Enter your choice: ");
            var input = Console.ReadKey();

            while (!inventoryHelper.CanAcceptKey(input.KeyChar))
            {
                Console.Write("\nEnter your choice: ");
                input = Console.ReadKey();
            }

            result = inventoryHelper.HandleInput(input.KeyChar);

            if (result.Handled)
            {
                Console.WriteLine("\nAction completed successfully.");
            }
            else
            {
                Console.WriteLine("\nInvalid action.");
            }
        } while (!result.ShouldExit);
    }

    public static void OnItemAdded(object sender, EventArgs e)
    {
        Console.WriteLine("\nItem added to inventory.");
    }
}