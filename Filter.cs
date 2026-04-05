using System;
using System.Collections.Generic;

class Program
{
    static List<T> Filter<T>(List<T> list, Func<T, bool> predicate)
    {
        List<T> result = new List<T>();

        foreach (var item in list)
        {
            if (predicate(item))
                result.Add(item);
        }

        return result;
    }

    static List<TResult> Transform<T, TResult>(List<T> list, Func<T, TResult> selector)
    {
        List<TResult> result = new List<TResult>();

        foreach (var item in list)
        {
            result.Add(selector(item));
        }

        return result;
    }

    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        // фильтрация чётных
        var evenNumbers = Filter(numbers, n => n % 2 == 0);

        // преобразование в строки
        var result = Transform(evenNumbers, n => $"Число: {n}");

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}