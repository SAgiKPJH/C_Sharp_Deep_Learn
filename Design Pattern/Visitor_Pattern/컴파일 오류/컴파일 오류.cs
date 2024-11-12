namespace Visitor_Pattern.컴파일_오류;

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
    public void Extractot2txt(PdfFile pdfFile) => Console.WriteLine("Extract PDF");
    public void Extractot2txt(PptFile pptFile) => Console.WriteLine("Extract PPT");
}