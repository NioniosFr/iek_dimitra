namespace ConsoleApp2;

public class MyJsonDocument : IDocument
{
    public string FileName { get; }

    public MyJsonDocument(string fileName)
    {
        FileName = fileName;
    }

    public void Open()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Print()
    {
        throw new NotImplementedException();
    }
}