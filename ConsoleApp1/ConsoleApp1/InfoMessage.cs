namespace ConsoleApp1;

public class InfoMessage : ILoggable
{
    private readonly string _message;

    public InfoMessage(string message)
    {
        this._message = message;
    }

    public void Log()
    {
        Console.WriteLine("Info: " + this._message);
    }
}