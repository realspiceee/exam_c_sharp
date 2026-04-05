using System;

class Vector2D
{
    public double X;
    public double Y;

    public Vector2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static Vector2D operator +(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2D operator -(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.X - b.X, a.Y - b.Y);
    }

    public static Vector2D operator *(Vector2D v, double number)
    {
        return new Vector2D(v.X * number, v.Y * number);
    }

    public static bool operator ==(Vector2D a, Vector2D b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Vector2D a, Vector2D b)
    {
        return a.X != b.X || a.Y != b.Y;
    }

    public override string ToString()
    {
        return "(" + X + "; " + Y + ")";
    }
}

class Program
{
    static void Main()
    {
        Vector2D v1 = new Vector2D(3, 4);
        Vector2D v2 = new Vector2D(1, 2);

        Console.WriteLine("v1 = " + v1);
        Console.WriteLine("v2 = " + v2);
        Console.WriteLine("v1 + v2 = " + (v1 + v2));
        Console.WriteLine("v1 - v2 = " + (v1 - v2));
        Console.WriteLine("v1 * 2 = " + (v1 * 2));
        Console.WriteLine("v1 == v2: " + (v1 == v2));
        Console.WriteLine("v1 != v2: " + (v1 != v2));
    }
}
