using System;

delegate double MathOperation(double a, double b);

class Program
{
    static double Add(double a, double b) => a + b;
    static double Subtract(double a, double b) => a - b;
    static double Multiply(double a, double b) => a * b;
    static double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Деление на ноль");

        return a / b;
    }

    static void ExecuteAndPrint(MathOperation op, double a, double b)
    {
        double result = op(a, b);
        Console.WriteLine(result);
    }

    static void Main()
    {
        MathOperation[] operations =
        {
            Add,
            Subtract,
            Multiply,
            Divide
        };

        double a = 10;
        double b = 2;

        foreach (var op in operations)
        {
            ExecuteAndPrint(op, a, b);
        }
    }
}