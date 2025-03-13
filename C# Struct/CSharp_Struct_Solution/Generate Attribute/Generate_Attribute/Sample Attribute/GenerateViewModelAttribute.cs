namespace Generate_Attribute.Sample_Attribute;

enum AccessModifier
{
    Public,
    Private,
    Protected,
    Internal,
    ProtectedInternal,
    PrivateProtected,
}
[AttributeUsage(AttributeTargets.Class)]
class GenerateViewModelAttribute : System.Attribute
{
    public bool ImplementINotifyPropertyChanging { get; set; }
    public bool ImplementISupportUIServices { get; set; }
}

[AttributeUsage(AttributeTargets.Field)]
class GeneratePropertyAttribute : System.Attribute
{
    public bool IsVirtual { get; set; }
    public string? OnChangedMethod { get; set; }
    public string? OnChangingMethod { get; set; }
    public AccessModifier SetterAccessModifier { get; set; }
}

[AttributeUsage(AttributeTargets.Method)]
class GenerateCommandAttribute : System.Attribute
{
    public bool AllowMultipleExecution { get; set; }
    public string? CanExecuteMethod { get; set; }
    public string? Name { get; set; }
}