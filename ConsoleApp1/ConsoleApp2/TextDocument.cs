namespace ConsoleApp2;

public class TextDocument : IDocument
{
    public string FileName { get; private set; }

    public TextDocument(string fileName)
    {
        FileName = fileName;
    }

    public void Open()
    {
        Console.WriteLine($"Opening Text Document: {FileName}");
    }

    public void Save()
    {
        Console.WriteLine($"Saving Text Document: {FileName}");
    }

    public void Print()
    {
        Console.WriteLine($"Printing Text Document: {FileName}");
    }
}