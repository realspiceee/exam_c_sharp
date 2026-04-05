using System;
using System.Collections.Generic;

interface ISwimmable
{
    void Swim();
}

interface IFlyable
{
    void Fly();
}

abstract class Animal
{
    public string Name;

    public Animal(string name)
    {
        Name = name;
    }

    public abstract void MakeSound();

    public virtual void Move()
    {
        Console.WriteLine(Name + " передвигается");
    }
}

class Duck : Animal, ISwimmable, IFlyable
{
    public Duck(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine(Name + ": Кря!");
    }

    public void Swim()
    {
        Console.WriteLine(Name + " плывёт");
    }

    public void Fly()
    {
        Console.WriteLine(Name + " летит");
    }
}

class Fish : Animal, ISwimmable
{
    public Fish(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine(Name + ": ...(молчит)");
    }

    public void Swim()
    {
        Console.WriteLine(Name + " плывёт в воде");
    }
}

class Eagle : Animal, IFlyable
{
    public Eagle(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine(Name + ": Клёкот!");
    }

    public void Fly()
    {
        Console.WriteLine(Name + " парит в небе");
    }
}

class Program
{
    static void Main()
    {
        List<Animal> zoo = new List<Animal>();
        zoo.Add(new Duck("Утка"));
        zoo.Add(new Fish("Карп"));
        zoo.Add(new Eagle("Орёл"));

        foreach (Animal animal in zoo)
        {
            animal.MakeSound();

            if (animal is ISwimmable swimmer)
                swimmer.Swim();

            if (animal is IFlyable flyer)
                flyer.Fly();

            Console.WriteLine();
        }
    }
}
