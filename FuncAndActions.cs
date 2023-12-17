namespace c_10_in_a_nutshell.FuncAndActions;

using c_10_in_a_nutshell.Delegates;

public static class Run
{
    #region FuncExample
    private static class DelegateHelper
    {
        public static double GetTax(double salary) => salary * .3;
    }

    public static void FuncExample()
    {
        var funcDelegate = new Func<double, double>(DelegateHelper.GetTax);

        Console.WriteLine($"{funcDelegate(100.1)}");
    }
    #endregion

    #region Action Example
    private static class Calculator
    {
        public static void Add(int a, int b)
        {
            Console.WriteLine($"Addition is {a + b}");
        }

        public static void Subtract(int a, int b)
        {
            Console.WriteLine($"Subtraction is {a - b}");
        }

        public static void Multiply(int a, int b)
        {
            Console.WriteLine($"Multiply {a * b}");
        }
    }

    public static void ActionExample()
    {
        var c = new Action<int, int>[] { Calculator.Add, Calculator.Subtract, Calculator.Multiply };

        Console.WriteLine("Enter Choice: 0 for add, 1 for subtract and 2 for multiply");
        var sNumber = Console.ReadLine();

        try
        {
           var choice = Convert.ToInt16(sNumber);
           c[choice](15, 10);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);            
        }
    }

    #endregion
}