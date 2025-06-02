namespace ConsoleApp2;

public static class DocumentFactory
{
    public static IDocument CreateDocument(string type, string fileName)
    {
        // do pattern matching
        return type switch
        {
            "txt" => new TextDocument(fileName),
            "pdf" => new PdfDocument(fileName),
            "xml" => new MyXmlDocument(),
            "json" => new MyJsonDocument(fileName),
            _ => throw new NotSupportedException($"Document type '{type}' is not supported.")
        };
    }
}
