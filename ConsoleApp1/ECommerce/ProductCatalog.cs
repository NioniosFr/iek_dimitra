namespace ECommerce;

public class ProductCatalog
{
    public delegate void ProductAddedEventHandler(Product product);

    private List<Product> products = new List<Product>();

    public event ProductAddedEventHandler ProductAdded;

    public void AddProduct(Product product)
    {
        products.Add(product);

        ProductAdded?.Invoke(product);
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }

    public List<Product> GetProducts()
    {
        return products;
    }

    public Product GetProductById(int id)
    {
        // return products.Find(p => p.ProductId == id);

        foreach (var product in products)
        {
            if (product.ProductId == id)
            {
                return product;
            }
        }

        return null;
    }

    public void DisplayProducts()
    {
        Console.WriteLine("------Product Catalog:------");
        foreach (var product in products)
        {
            Console.WriteLine();
            Console.WriteLine(product.ToString());
        }

        Console.WriteLine("------------------");
    }
}