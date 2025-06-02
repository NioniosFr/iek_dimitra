namespace ConsoleApp1;

public interface IShape
{ 
    double GetArea();
}

public class Rectangle : IShape 
{
    public double GetArea()
    {
        return 0;
    }
}

public class Circle : IShape 
{
    public double GetArea()
    {
        return 0;
    }
}