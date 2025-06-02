namespace ECommerce;

public class Product : IOrderable
{
    public int ProductId { get; set; } // SKU - Stock Keeping Unit
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"Product ID: {ProductId}, \n" +
               $"Name: {Name}, \n" +
               $"Description: {Description}, \n" +
               $"Price: {Price:C}";
    }

    public decimal CalculateTotalPrice(int quantity)
    {
        return quantity * Price;
    }
}