namespace Visitor_Pattern.요구사항;

public abstract class ResourceFile
{
    protected readonly string filePath;

    public ResourceFile(string filePath)
    {
        this.filePath = filePath;
    }

    abstract public void Extract2txt();
}

public class PdfFile : ResourceFile
{
    public PdfFile(string filePath) : base(filePath) { }

    public override void Extract2txt()
    {
        Console.WriteLine("Extract PDF");
    }
    
    // 추가 기능 생길때마다 각각 추가해야 합니다.
}

public class PptFile : ResourceFile
{
    public PptFile(string filePath) : base(filePath) { }

    public override void Extract2txt()
    {
        Console.WriteLine("Extract PPT");
    }

    // 추가 기능 생길때마다 각각 추가해야 합니다.
}

// ...