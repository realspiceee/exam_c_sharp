using System;

interface IResizable
{
    void Resize(double factor);
}

interface IDrawable
{
    void Draw();
}

class Square : IResizable, IDrawable
{
    public int Size { get; private set; }

    public Square(int size)
    {
        Size = size;
    }

    public void Resize(double factor)
    {
        if (factor <= 0)
            throw new ArgumentException("Коэффициент должен быть положительным");

        Size = (int)(Size * factor);
    }

    public void Draw()
    {
        for (int i = 0; i < Size; i++)
        {
            Console.WriteLine(new string('#', Size));
        }
    }
}

class Program
{
    static void Main()
    {
        Square square = new Square(2);

        // через IResizable
        IResizable resizable = square;
        resizable.Resize(2);

        // через IDrawable
        IDrawable drawable = square;
        drawable.Draw();
    }
}