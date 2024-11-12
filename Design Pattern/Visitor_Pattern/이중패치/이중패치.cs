namespace Visitor_Pattern.이중패치;

public abstract class ResourceFile
{
    protected readonly string filePath;

    public ResourceFile(string filePath)
    {
        this.filePath = filePath;
    }
}

public class PdfFile : ResourceFile
{
    public PdfFile(string filePath) : base(filePath) { }
}

public class PptFile : ResourceFile
{
    public PptFile(string filePath) : base(filePath) { }
}

public class Extractor
{
    public void Extractot2txt(ResourceFile resource)
    {
        if (resource is PdfFile pdfFile)
        {
            Extractot2txt(pdfFile);
            return;
        }
        if (resource is PptFile pptFile)
        { 
            Extractot2txt(pptFile);
            return;
        }

        throw new Exception("No Type");
    }
    
    public void Extractot2txt(PdfFile pdfFile) => Console.WriteLine("Extract PDF");
    
    public void Extractot2txt(PptFile pptFile) => Console.WriteLine("Extract PPT");
}