namespace Delegate;

public static class MetodDelegate
{
    public static void Add(int a, int b)
    {
        Console.WriteLine(a  + b);
    }
    public static int subtraction(int a, int b)
    {
        return a - b;
    }
    public static int multiplication(int a, int b)
    {
        return a * b;
    }
    public static double division(int a, int b)
    {
        return a / b;
    }
}