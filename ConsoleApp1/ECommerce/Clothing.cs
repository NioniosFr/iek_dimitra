namespace ECommerce;

public class Clothing : Product
{
    public int Size { get; set; }
    public int Material { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()}, Size: {Size}, Material: {Material}";
    }
}