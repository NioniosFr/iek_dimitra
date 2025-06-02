namespace ConsoleApp1;

public class StringDataRetriever : IDataRetriever
{
    public string[] GetData()
    {
        return
        [
            "string1",
            "string2",
            "string3"
        ];
    }

    public string GetName()
    {
        return "StringDataRetriever";
    }
}