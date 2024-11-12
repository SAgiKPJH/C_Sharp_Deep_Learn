namespace Visitor_Pattern.비지터_패턴;

public abstract class ResourceFile
{
    protected readonly string filePath;

    public ResourceFile(string filePath)
    {
        this.filePath = filePath;
    }

    abstract public void Accept(Extractor extractor);
}

public class PdfFile : ResourceFile
{
    public PdfFile(string filePath) : base(filePath) { }

    public override void Accept(Extractor extractor) => extractor.Extractot2txt(this);
}

public class PptFile : ResourceFile
{
    public PptFile(string filePath) : base(filePath) { }
    public override void Accept(Extractor extractor) => extractor.Extractot2txt(this);
}

public class Extractor
{
    public void Extractot2txt(PdfFile pdfFile) => Console.WriteLine("Extract PDF");
    public void Extractot2txt(PptFile pptFile) => Console.WriteLine("Extract PPT");
}