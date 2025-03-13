using DevExpress.Mvvm.CodeGenerators;

namespace Motivate_Generate_Attribute;

[GenerateViewModel]
public partial class SampleViewModel
{
    [GenerateProperty]
    string age;

    [GenerateProperty]
    string name;

    [GenerateProperty]
    string address;
}