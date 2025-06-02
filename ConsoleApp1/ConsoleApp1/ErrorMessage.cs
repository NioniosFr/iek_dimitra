namespace ConsoleApp1;

public class ErrorMessage : ILoggable
{
    private readonly string _message;

    public ErrorMessage(string message)
    {
        _message = message;
    }

    public void Log()
    {
        Console.WriteLine("Error: " + _message);
    }
}