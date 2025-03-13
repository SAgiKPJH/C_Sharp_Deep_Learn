namespace Generate_Attribute.Attribute;

class History : System.Attribute  // 상속
{
    private string programmer;

    public double Version
    {
        get;
        set;
    }

    public string Changes
    {
        get;
        set;
    }

    // 생성자
    public History(string programmer)
    {
        this.programmer = programmer;
        Version = 1.0;
        Changes = "First release";
    }

    public string Programmer
    {
        get { return programmer; }
    }
}
// History 클래스 사용
[History("Sean", Version = 0.1, Changes = "2017-11-01 Created class stub")]
class MyClass
{
    public void Func()
    {
        Console.WriteLine("Func()");
    }
}