namespace ConsoleApp2;

/// <summary>
/// Document Creator
/// </summary>
class Program
{
    /// <summary>
    /// We need to create different types of documents in our application
    /// (e.g., reports, invoices, letters).
    ///
    /// How can we do this in a flexible way so that we can easily add new document
    /// types in the future?
    /// </summary>
    static void Main(string[] args)
    {
        // Factory method to create the document
        IDocument document = DocumentFactory.CreateDocument(args[0], args[1]);

        // Business logic
        document.Open();

        document.Save();
        
        document.Print();
    }
}