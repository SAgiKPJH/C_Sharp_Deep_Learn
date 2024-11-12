namespace Visitor_Pattern.다중_기능;

public abstract class ResourceFile
{
    protected readonly string filePath;

    public ResourceFile(string filePath)
    {
        this.filePath = filePath;
    }

    abstract public void Accept(IVIsitor visitor);
}

public class PdfFile : ResourceFile
{
    public PdfFile(string filePath) : base(filePath) { }

    public override void Accept(IVIsitor visitor) => visitor.Visit(this);
}

public class PptFile : ResourceFile
{
    public PptFile(string filePath) : base(filePath) { }
    public override void Accept(IVIsitor visitor) => visitor.Visit(this);
}

public interface IVIsitor
{
    void Visit(PdfFile pdfFile);
    void Visit(PptFile pptFile);
}

public class Extractor : IVIsitor
{
    public void Visit(PdfFile pdfFile) => Console.WriteLine("Extract PDF");
    public void Visit(PptFile pptFile) => Console.WriteLine("Extract PPT");
}

public class FileSize : IVIsitor
{
    public void Visit(PdfFile pdfFile) => Console.WriteLine("Size : 188KB");
    public void Visit(PptFile pptFile) => Console.WriteLine("Size : 153KB");
}