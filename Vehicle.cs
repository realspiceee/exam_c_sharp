using System;

class Vehicle
{
    public string Brand;
    public int Year;

    public Vehicle(string brand, int year)
    {
        Brand = brand;
        Year = year;
    }

    public virtual string GetInfo()
    {
        return "Транспорт: " + Brand + ", год: " + Year;
    }
}

class Car : Vehicle
{
    public int Doors;

    public Car(string brand, int year, int doors) : base(brand, year)
    {
        Doors = doors;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + ", дверей: " + Doors;
    }
}

class ElectricCar : Car
{
    public int Battery;

    public ElectricCar(string brand, int year, int doors, int battery)
        : base(brand, year, doors)
    {
        Battery = battery;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + ", батарея: " + Battery + " кВт·ч";
    }
}

class Program
{
    static void Main()
    {
        Vehicle car = new ElectricCar("Tesla", 2023, 4, 100);
        Console.WriteLine(car.GetInfo());
    }
}
