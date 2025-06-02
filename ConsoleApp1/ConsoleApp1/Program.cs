namespace ConsoleApp1;

class Program
{
    public class MessageFactory
    {
        public static ILoggable CreateMessage(string type, string message)
        {
            switch (type)
            {
                case "warning":
                    return new WarningMessage(message);
                case "info":
                    return new InfoMessage(message);
                case "error":
                    return new ErrorMessage(message);
            }

            return new ErrorMessage(message);
        }
    }

    static void Main(string[] args)
    {
        ILoggable message = MessageFactory.CreateMessage("warning", "This is a warning message");
        message.Log();

        message = MessageFactory.CreateMessage("info", "This is an info message");
        message.Log();

        message = MessageFactory.CreateMessage("error", "This is an error message");
        message.Log();
    }


    static void Main1(string[] args)
    {
        ErrorMessage errorMessage = new ErrorMessage("problem occured");

        errorMessage.Log();

        ILoggable loggable = errorMessage;

        loggable.Log();
    }

    private static IDataRetriever GetRandomRetriever()
    {
        Random random = new Random();
        int choice = random.Next(0, 2);

        if (choice == 0)
        {
            return new StringDataRetriever();
        }
        else
        {
            return new StringLineFileReader();
        }
    }

    static void Main2(string[] args)
    {
        IDataRetriever stringData = GetRandomRetriever();

        Console.WriteLine("Data retrieved type: " + stringData.GetName());


        foreach (var line in stringData.GetData())
        {
            Console.WriteLine(line);
        }
    }
}