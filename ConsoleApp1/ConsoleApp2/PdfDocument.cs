namespace ConsoleApp2;

public class PdfDocument : IDocument
{
    public string FileName { get; private set; }

    public PdfDocument(string fileName)
    {
        FileName = fileName;
    }

    public void Open()
    {
        Console.WriteLine($"Opening Pdf Document: {FileName}");
    }

    public void Save()
    {
        Console.WriteLine($"Saving Pdf Document: {FileName}");
    }

    public void Print()
    {
        Console.WriteLine($"Printing Pdf Document: {FileName}");
    }
}