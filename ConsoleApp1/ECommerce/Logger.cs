namespace ECommerce;

public class Logger
{
    public void OrderPlaced(Order order)
    {
        // In a real-world application, you would write to a file or a logging system
        Console.WriteLine($"Log: Order placed {order.ToString()}");
    }
    
    public void ProductAdded(Product product)
    {
        // In a real-world application, you would write to a file or a logging system
        Console.WriteLine($"Log: Product added {product.ToString()}");
    }
}