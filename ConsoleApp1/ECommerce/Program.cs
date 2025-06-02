namespace ECommerce;

class Program
{
    static void Main(string[] args)
    {
        var book = ProductFactory.CreateProduct("book",
            1, "Moby Dick", "A novel about a whale.", 19.99m
            , "John Doe", "123-4567890123"
        );

        var electronics =
            ProductFactory.CreateProduct("electronics",
                2, "Smartphone", "A latest model smartphone.", 699.99m,
                "24", "100"
            );

        var clothing = ProductFactory.CreateProduct("clothing", 3,
            "T-Shirt", "A comfortable cotton t-shirt.", 19.99m,
            "42", "1"
        );
        
        var logger = new Logger();

        ProductCatalog catalog = new ProductCatalog();
        catalog.ProductAdded += logger.ProductAdded;
        catalog.ProductAdded += p => { Console.WriteLine("I also got called"); };

        catalog.AddProduct(book);
        catalog.AddProduct(electronics);
        catalog.AddProduct(clothing);

        catalog.DisplayProducts();

        Order order = new Order();
        order.OrderPlaced += logger.OrderPlaced;
        
        order.AddItem(catalog.GetProductById(1));
        order.AddItem(catalog.GetProductById(2));
        
        // simulate placing the order
        order.PlaceOrder();

        Console.WriteLine("Order Total: " + order.CalculateOrderTotal());
    }
}