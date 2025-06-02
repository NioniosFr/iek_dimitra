namespace ECommerce;

public class Order
{
    public delegate void OrderPlacedEventHandler(Order order);

    private List<IOrderable> _items = new List<IOrderable>();

    public event OrderPlacedEventHandler OrderPlaced;

    public void AddItem(IOrderable item)
    {
        _items.Add(item);
    }

    public decimal CalculateOrderTotal()
    {
        decimal total = 0;
        foreach (var item in _items)
        {
            total += item.CalculateTotalPrice(1); // Assuming quantity of 1 for simplicity
        }

        return total;
    }

    public override string ToString()
    {
        return $"Total Order Amount: {CalculateOrderTotal()}, Items Count: {_items.Count}";
    }

    public void PlaceOrder()
    {
        // Logic to place the order
        OrderPlaced?.Invoke(this);
    }
}