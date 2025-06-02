namespace ConsoleApp1;

public class WarningMessage : ILoggable
{
    private readonly string _message;

    public WarningMessage(string message)
    {
        this._message = message;
    }

    public void Log()
    {
        Console.WriteLine("Warning: " + this._message);
    }
}