using Generate_Attribute.Attribute;
using Generate_Attribute.Sample_Attribute;

var sampleViewModel = new SampleViewModel();


// Attribute 클래스 정의된 내용을 Reflection으로 가져오기
Type type = typeof(MyClass);
// MyClass에 적용된 History Attribute 정보 가져오기
var attributes = type.GetCustomAttributes(typeof(History), false);
if (attributes.Length > 0)
{
    History history = (History)attributes[0];
    Console.WriteLine($"Programmer: {history.Programmer}");
    Console.WriteLine($"Version: {history.Version}");
    Console.WriteLine($"Changes: {history.Changes}");
}