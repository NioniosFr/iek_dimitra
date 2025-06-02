namespace ConsoleApp1;

public class StringLineFileReader : IDataRetriever
{
    public string[] GetData()
    {
        return File.ReadAllLines("data.txt");
    }

    public string GetName()
    {
        return "StringLineFileReader";
    }
}