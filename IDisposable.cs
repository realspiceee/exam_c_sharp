using System;
using System.IO;

class FileProcessor : IDisposable
{
    private StreamWriter writer;

    public FileProcessor(string filePath)
    {
        writer = new StreamWriter(filePath);
        Console.WriteLine("Файл открыт");
    }

    public void WriteLine(string text)
    {
        writer.WriteLine(text);
    }

    public void Dispose()
    {
        writer.Close();
        Console.WriteLine("Ресурсы освобождены");
    }
}

class Program
{
    static void Main()
    {
        string path = "result.txt";

        using (FileProcessor fp = new FileProcessor(path))
        {
            fp.WriteLine("Первая строка");
            fp.WriteLine("Вторая строка");
            fp.WriteLine("Третья строка");
        }

        Console.WriteLine("\nСодержимое файла:");
        Console.WriteLine(File.ReadAllText(path));
    }
}

