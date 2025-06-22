using System;


public interface IDocument
{
    void Open();
    void Save();
}

public class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Word document...");
    public void Save() => Console.WriteLine("Saving Word document...");
}

public class PdfDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening PDF document...");
    public void Save() => Console.WriteLine("Saving PDF document...");
}

public class ExcelDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Excel document...");
    public void Save() => Console.WriteLine("Saving Excel document...");
}

public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
    
    
    public void LogCreation() => Console.WriteLine("Document created at " + DateTime.Now);
}

public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new WordDocument();
}

public class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new PdfDocument();
}

public class ExcelDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new ExcelDocument();
}


class Program
{
    static void Main()
    {
        Console.WriteLine("Document Management System\n");
        
        
        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument wordDoc = wordFactory.CreateDocument();
        wordFactory.LogCreation();
        wordDoc.Open();
        wordDoc.Save();
        
        Console.WriteLine();
        
        
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        IDocument pdfDoc = pdfFactory.CreateDocument();
        pdfFactory.LogCreation();
        pdfDoc.Open();
        pdfDoc.Save();
        
        Console.WriteLine();
        
        
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        IDocument excelDoc = excelFactory.CreateDocument();
        excelFactory.LogCreation();
        excelDoc.Open();
        excelDoc.Save();
    }
}
