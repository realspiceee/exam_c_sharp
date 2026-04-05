using System;

struct Point
{
    public double X;
    public double Y;
}

class PointRef
{
    public double X;
    public double Y;
}

class point_x_y
{
    static void Main()
    {
        // Значимый тип (struct)
        Point p1 = new Point { X = 1, Y = 2 };
        Point p2 = p1;
        p2.X = 10;

        Console.WriteLine("Struct:");
        Console.WriteLine($"p1.X = {p1.X}, p2.X = {p2.X}");

        // Ссылочный тип (class)
        PointRef r1 = new PointRef { X = 1, Y = 2 };
        PointRef r2 = r1;
        r2.X = 10;

        Console.WriteLine("Class:");
        Console.WriteLine($"r1.X = {r1.X}, r2.X = {r2.X}");
    }
}