namespace ECommerce;

public class Electronic : Product
{
    public int Warranty { get; set; }
    public int PowerConsumption { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()}, Warranty: {Warranty}, PowerConsumption: {PowerConsumption}";
    }
}