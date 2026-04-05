using System;
using System.Collections.Generic;

interface IPayable
{
    decimal CalculatePayment();
}

abstract class Employee : IPayable
{
    public string Name { get; set; }
    public int HoursWorked { get; set; }

    public Employee(string name, int hoursWorked)
    {
        Name = name;
        HoursWorked = hoursWorked;
    }

    public abstract decimal CalculatePayment();
}

class FullTimeEmployee : Employee
{
    public decimal FixedSalary { get; set; }

    public FullTimeEmployee(string name, int hoursWorked, decimal fixedSalary)
        : base(name, hoursWorked)
    {
        FixedSalary = fixedSalary;
    }

    public override decimal CalculatePayment()
    {
        return FixedSalary;
    }
}

class PartTimeEmployee : Employee
{
    public decimal HourlyRate { get; set; }

    public PartTimeEmployee(string name, int hoursWorked, decimal hourlyRate)
        : base(name, hoursWorked)
    {
        HourlyRate = hourlyRate;
    }

    public override decimal CalculatePayment()
    {
        return HoursWorked * HourlyRate;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new FullTimeEmployee("Иван", 160, 50000),
            new PartTimeEmployee("Анна", 80, 400),
            new PartTimeEmployee("Пётр", 100, 350)
        };

        Console.WriteLine("Платёжная ведомость:");

        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.Name}: {emp.CalculatePayment()}");
        }
    }
}