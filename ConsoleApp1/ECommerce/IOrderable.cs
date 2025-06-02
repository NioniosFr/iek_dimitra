namespace ECommerce;

public interface IOrderable
{
    decimal CalculateTotalPrice(int quantity);
}