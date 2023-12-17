# Delegates

A delegate is an object that knows how to call a method, is similar function pointer in C. See this example from [function-pointer-in-c]( https://www.geeksforgeeks.org/function-pointer-in-c):

```c
#include <stdio.h> 
void add(int a, int b) 
{ 
    printf("Addition is %d\n", a+b); 
} 
void subtract(int a, int b) 
{ 
    printf("Subtraction is %d\n", a-b); 
} 
void multiply(int a, int b) 
{ 
    printf("Multiplication is %d\n", a*b); 
} 
  
int main() 
{ 
    // fun_ptr_arr is an array of function pointers 
    void (*fun_ptr_arr[])(int, int) = {add, subtract, multiply}; 
    unsigned int ch, a = 15, b = 10; 
  
    printf("Enter Choice: 0 for add, 1 for subtract and 2 "
            "for multiply\n"); 
    scanf("%d", &ch); 
  
    if (ch > 2) return 0; 
  
    (*fun_ptr_arr[ch])(a, b); 
  
    return 0; 
}
```

in C# we can do the same thing in this way, [delegate_example_01](delegates.cs):

```csharp
namespace c_10_in_a_nutshell.Delegates;

delegate void Calc(int a, int b);

public static class Calculator
{
    static void Add(int a, int b)
    {
        Console.WriteLine($"Addition is {a + b}");
    }

    static void Subtract(int a, int b)
    {
        Console.WriteLine($"Subtraction is {a - b}");
    }

    static void Multiply(int a, int b)
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
           c[choice](15, 10);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);            
        }
    }
}
```

If i run in all calculator methods i can use the *multicast property*: 

```csharp
Calc c = Add;
c += Subtract;
c += Multiply;

c(15, 10);
```

# Events

When use delegates a pattern emerge: broadcaster and subscriber. The event is to prevent subscribers from interfering with one another.

see the [example](events) their definition adheres to a standard pattern. Above simplified event example:

```csharp
namespace c_10_in_a_nutshell.Events;

public delegate void PriceChangedHandler(decimal oldPrive, decimal newPrice);

public static class Run
{
    private class Stock
    {
        string _symbol;
        decimal _price;

        public Stock(string symbol) => _symbol = symbol;

        public event PriceChangedHandler? PriceChanged;

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price == value) return;
                decimal oldPrice = _price;
                _price = value;
                PriceChanged?.Invoke(oldPrice, _price);
            }
        }
    }

    private static void Print(decimal old, decimal neww) 
    {
        Console.WriteLine($"the old price was {old}, the new is {neww}");
    }

    public static void Example01()
    {
        var a = new Stock("milk");
        a.PriceChanged += Print;
        a.Price = 5M;
        a.Price *= 2;
    }
}

// Output
// the old price was 0, the new is 5
// the old price was 5, the new is 10
```
# Func and Action delegates

The *func* delegate points to a method that accepts parameters and returns a value. The action is the same thing but not return a value.

See a example of Func:

```csharp
private static class DelegateHelper
{
    public static double GetTax(double salary) => salary * .3;
}

public static void FuncExample()
{
    var funcDelegate = new Func<double, double>(DelegateHelper.GetTax); 
    
    Console.WriteLine($"{funcDelegate(100.1)}");
}
```

see an example of Action:

```csharp
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
```
