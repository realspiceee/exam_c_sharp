using System;
using System.IO;

class Program
{
    static void Main()
    {
        string folder = "StudentData";
        string file = folder + "/students.txt";

        // Создаём папку если нет
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        // Записываем студентов
        StreamWriter writer = new StreamWriter(file);
        writer.WriteLine("Иван Петров, 20, 4.5");
        writer.WriteLine("Мария Сидорова, 21, 3.8");
        writer.WriteLine("Алексей Козлов, 19, 5.0");
        writer.WriteLine("Ольга Новикова, 22, 3.2");
        writer.WriteLine("Дмитрий Соколов, 20, 4.1");
        writer.Close();

        Console.WriteLine("Файл записан.\n");

        // Читаем и выводим студентов с оценкой выше 4.0
        Console.WriteLine("Студенты с оценкой выше 4.0:");
        StreamReader reader = new StreamReader(file);
        int lineCount = 0;
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            lineCount++;
            string[] parts = line.Split(',');
            double grade = double.Parse(parts[2].Trim(),
                System.Globalization.CultureInfo.InvariantCulture);

            if (grade > 4.0)
                Console.WriteLine(line);
        }
        reader.Close();

        Console.WriteLine("\nВсего строк в файле: " + lineCount);
    }
}
