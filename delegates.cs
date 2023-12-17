namespace c_10_in_a_nutshell.Delegates;

public static class Calculator
{
    private delegate void Calc(int a, int b);
    
    private static void Add(int a, int b)
    {
        Console.WriteLine($"Addition is {a + b}");
    }

    private static void Subtract(int a, int b)
    {
        Console.WriteLine($"Subtraction is {a - b}");
    }

    private static void Multiply(int a, int b)
    {
        Console.WriteLine($"Multiply {a * b}");
    }

    public static void Run()
    {
        Calc[] c = { Add, Subtract, Multiply };

        Console.WriteLine("Enter Choice: 0 for add, 1 for subtract and 2 for multiply");
        var sNumber = Console.ReadLine();

        try
        {
           var choice = Convert.ToInt16(sNumber);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);            
        }
    }

    public static void Run2()
    {

        Calc c = Add;
        c += Subtract;
        c += Multiply;

        c(15, 10);
    }
}
