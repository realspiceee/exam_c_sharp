using System;

abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();

    public virtual void Describe()
    {
        Console.WriteLine($"Тип: {GetType().Name}, Площадь: {Area():F2}, Периметр: {Perimeter():F2}");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area()
    {
        return Width * Height;
    }

    public override double Perimeter()
    {
        return 2 * (Width + Height);
    }
}

class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public override double Area()
    {
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public override double Perimeter()
    {
        return A + B + C;
    }
}

class Program
{
    static void Main()
    {
        Shape[] shapes = new Shape[]
        {
            new Circle { Radius = 3 },
            new Rectangle { Width = 4, Height = 5 },
            new Triangle { A = 3, B = 4, C = 5 }
        };

        foreach (var shape in shapes)
        {
            shape.Describe();
        }
    }
}