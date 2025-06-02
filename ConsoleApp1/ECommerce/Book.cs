namespace ECommerce;

public class Book : Product
{
    public string Author { get; set; }
    public string ISBN { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()}, Author: {Author}, ISBN: {ISBN}";
    }
}