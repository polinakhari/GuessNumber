namespace Reflection;

public class TestedClass
{
    public int i1, i2, i3, i4, i5;
    public static TestedClass Get() => new () { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
}