namespace ECommerce;

public static class ProductFactory
{
    public static Product CreateProduct(string type, int id, string name, string description, decimal price,
        params string[] args
    )
    {
        return type.ToLower() switch
        {
            "book" => new Book
            {
                ProductId = id, Name = name, Description = description, Price = price, Author = args[0], ISBN = args[1]
            },
            "clothing" => new Clothing
            {
                ProductId = id, Name = name, Description = description, Price = price, Size = int.Parse(args[0]),
                Material = int.Parse(args[1])
            },
            "electronics" => new Electronic
            {
                ProductId = id, Name = name, Description = description, Price = price, Warranty = int.Parse(args[0]),
                PowerConsumption = int.Parse(args[1])
            },
            _ => throw new ArgumentException("Invalid product type")
        };
    }
}