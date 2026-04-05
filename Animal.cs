using System;
using System.Collections.Generic;

class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual string Speak()
    {
        return "Some sound";
    }
}

class Dog : Animal
{
    public override string Speak()
    {
        return "Woof";
    }
}

class Cat : Animal
{
    public override string Speak()
    {
        return "Meow";
    }
}

class Parrot : Animal
{
    public override string Speak()
    {
        return "Squawk";
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog { Name = "Бобик", Age = 3 },
            new Cat { Name = "Мурка", Age = 2 },
            new Parrot { Name = "Кеша", Age = 1 }
        };

        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.Name}: {animal.Speak()}");
        }
    }
}