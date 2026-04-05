using System;

class Matrix
{
    private double[,] data;
    public int Rows;
    public int Cols;

    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        data = new double[rows, cols];
    }

    public double this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                throw new Exception("Индекс за пределами матрицы");
            return data[row, col];
        }
        set
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                throw new Exception("Индекс за пределами матрицы");
            data[row, col] = value;
        }
    }

    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
                Console.Write(data[i, j] + "\t");
            Console.WriteLine();
        }
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new Exception("Размеры матриц не совпадают");

        Matrix result = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] + b[i, j];
        return result;
    }
}

class Program
{
    static void Main()
    {
        Matrix m1 = new Matrix(2, 2);
        m1[0, 0] = 1; m1[0, 1] = 2;
        m1[1, 0] = 3; m1[1, 1] = 4;

        Matrix m2 = new Matrix(2, 2);
        m2[0, 0] = 10; m2[0, 1] = 20;
        m2[1, 0] = 30; m2[1, 1] = 40;

        Console.WriteLine("Матрица 1:");
        m1.Print();

        Console.WriteLine("Матрица 2:");
        m2.Print();

        Console.WriteLine("Сумма:");
        (m1 + m2).Print();
    }
}
