
Console.WriteLine("\n\n------요구 사항--------\n");

var resourceFiles1 = new List<Visitor_Pattern.요구사항.ResourceFile>()
{
    new Visitor_Pattern.요구사항.PdfFile("a.pdf"),
    new Visitor_Pattern.요구사항.PptFile("a.ppt"),
};

foreach(var resourceFile in resourceFiles1)
    resourceFile.Extract2txt();


Console.WriteLine("\n\n------컴파일 오류--------\n");

var resourceFiles2 = new List<Visitor_Pattern.컴파일_오류.ResourceFile>()
{
    new Visitor_Pattern.컴파일_오류.PdfFile("a.pdf"),
    new Visitor_Pattern.컴파일_오류.PptFile("a.ppt"),
};

var extractor = new Visitor_Pattern.컴파일_오류.Extractor();

// foreach (var resourceFile in resourceFiles2)
//     extractor.Extractot2txt(resourceFile);


Console.WriteLine("\n\n------비지터 패턴--------\n");

var resourceFiles3 = new List<Visitor_Pattern.비지터_패턴.ResourceFile>()
{
    new Visitor_Pattern.비지터_패턴.PdfFile("a.pdf"),
    new Visitor_Pattern.비지터_패턴.PptFile("a.ppt"),
};

var extractor3 = new Visitor_Pattern.비지터_패턴.Extractor();
foreach (var resourceFile in resourceFiles3)
    resourceFile.Accept(extractor3);


Console.WriteLine("\n\n------비지터 패턴 다중 기능--------\n");

var resourceFiles4 = new List<Visitor_Pattern.다중_기능.ResourceFile>()
{
    new Visitor_Pattern.다중_기능.PdfFile("a.pdf"),
    new Visitor_Pattern.다중_기능.PptFile("a.ppt"),
};

Visitor_Pattern.다중_기능.IVIsitor extractor4 = new Visitor_Pattern.다중_기능.Extractor();
Visitor_Pattern.다중_기능.IVIsitor fileSize4 = new Visitor_Pattern.다중_기능.FileSize();
foreach (var resourceFile in resourceFiles4)
{
    resourceFile.Accept(extractor4);
    resourceFile.Accept(fileSize4);
}


Console.WriteLine("\n\n------이중 패치 따라해본 내용--------\n");

var resourceFiles5 = new List<Visitor_Pattern.이중패치.ResourceFile>()
{
    new Visitor_Pattern.이중패치.PdfFile("a.pdf"),
    new Visitor_Pattern.이중패치.PptFile("a.ppt"),
};

var extractor5 = new Visitor_Pattern.이중패치.Extractor();

foreach (var resourceFile in resourceFiles5)
     extractor5.Extractot2txt(resourceFile);