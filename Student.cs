using System;

class Student
{
    private string name;
    private int age;
    private double gpa;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Имя не может быть пустым");

            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 16 || value > 99)
                throw new ArgumentOutOfRangeException("Возраст должен быть от 16 до 99");

            age = value;
        }
    }

    public double GPA
    {
        get { return gpa; }
        set
        {
            if (value < 0.0 || value > 5.0)
                throw new ArgumentOutOfRangeException("GPA должен быть от 0.0 до 5.0");

            gpa = value;
        }
    }

    public bool IsExcellent
    {
        get { return GPA >= 4.5; }
    }
}

class Program
{
    static void Main()
    {
        // корректная инициализация
        Student s1 = new Student
        {
            Name = "Иван",
            Age = 20,
            GPA = 4.7
        };

        Console.WriteLine($"{s1.Name}, Excellent: {s1.IsExcellent}");

        // некорректная инициализация
        try
        {
            Student s2 = new Student
            {
                Name = "",
                Age = 15,
                GPA = 6.0
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
} 