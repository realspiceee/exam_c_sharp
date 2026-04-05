using System;
using System.Collections.Generic;
using System.IO;

abstract class LibraryItem
{
    public string Title;
    public string Author;
    public int Year;

    public LibraryItem(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public abstract string GetInfo();
}

// Интерфейс выдачи
interface IBorrowable
{
    bool IsAvailable { get; }
    void Borrow(string userName);
    void Return();
}

// Книга
class Book : LibraryItem, IBorrowable
{
    public string ISBN;
    public int Pages;
    public bool IsAvailable { get; private set; } = true;
    private string borrowedBy = "";

    public Book(string title, string author, int year, string isbn, int pages)
        : base(title, author, year)
    {
        ISBN = isbn;
        Pages = pages;
    }

    public void Borrow(string userName)
    {
        if (!IsAvailable)
        {
            Console.WriteLine("Книга уже выдана!");
            return;
        }
        IsAvailable = false;
        borrowedBy = userName;
    }

    public void Return()
    {
        IsAvailable = true;
        borrowedBy = "";
    }

    public override string GetInfo()
    {
        string status = IsAvailable ? "в наличии" : "у " + borrowedBy;
        return "[Книга] " + Title + " — " + Author +
               " (" + Year + "), ISBN: " + ISBN +
               ", стр: " + Pages + " [" + status + "]";
    }

    public override string ToString()
    {
        return "BOOK|" + Title + "|" + Author + "|" + Year + "|" + ISBN + "|" + Pages;
    }
}

// Журнал
class Magazine : LibraryItem, IBorrowable
{
    public int Issue;
    public string Month;
    public bool IsAvailable { get; private set; } = true;
    private string borrowedBy = "";

    public Magazine(string title, string author, int year, int issue, string month)
        : base(title, author, year)
    {
        Issue = issue;
        Month = month;
    }

    public void Borrow(string userName)
    {
        if (!IsAvailable)
        {
            Console.WriteLine("Журнал уже выдан!");
            return;
        }
        IsAvailable = false;
        borrowedBy = userName;
    }

    public void Return()
    {
        IsAvailable = true;
        borrowedBy = "";
    }

    public override string GetInfo()
    {
        string status = IsAvailable ? "в наличии" : "у " + borrowedBy;
        return "[Журнал] " + Title + " — " + Author +
               " (" + Year + "), №" + Issue +
               ", " + Month + " [" + status + "]";
    }

    public override string ToString()
    {
        return "MAGAZINE|" + Title + "|" + Author + "|" + Year + "|" + Issue + "|" + Month;
    }
}

// Каталог
class Catalog
{
    private List<LibraryItem> items = new List<LibraryItem>();

    public event EventHandler<string> ItemBorrowed;

    public void Add(LibraryItem item)
    {
        items.Add(item);
    }

    public void BorrowItem(IBorrowable item, string userName)
    {
        item.Borrow(userName);
        LibraryItem li = (LibraryItem)item;
        ItemBorrowed?.Invoke(this, "\"" + li.Title + "\" выдана: " + userName);
    }

    public void PrintAll()
    {
        foreach (LibraryItem item in items)
            Console.WriteLine(item.GetInfo());
    }

    public void FindByAuthor(string author)
    {
        Console.WriteLine("Поиск по автору: " + author);
        foreach (LibraryItem item in items)
        {
            if (item.Author == author)
                Console.WriteLine(item.GetInfo());
        }
    }

    public void SaveToFile(string path)
    {
        StreamWriter writer = new StreamWriter(path);
        foreach (LibraryItem item in items)
            writer.WriteLine(item.ToString());
        writer.Close();
        Console.WriteLine("Каталог сохранён в файл: " + path);
    }

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден");
            return;
        }

        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            string[] p = line.Split('|');
            if (p[0] == "BOOK")
                items.Add(new Book(p[1], p[2], int.Parse(p[3]), p[4], int.Parse(p[5])));
            else if (p[0] == "MAGAZINE")
                items.Add(new Magazine(p[1], p[2], int.Parse(p[3]), int.Parse(p[4]), p[5]));
        }
        Console.WriteLine("Каталог загружен из файла: " + path);
    }
}

class Program
{
    static void Main()
    {
        Catalog catalog = new Catalog();

        catalog.ItemBorrowed += (sender, message) =>
        {
            Console.WriteLine("[Событие] " + message);
        };

        catalog.Add(new Book("Мастер и Маргарита", "Булгаков", 1967, "978-5-17-1", 480));
        catalog.Add(new Book("1984", "Оруэлл", 1949, "978-5-17-2", 320));
        catalog.Add(new Magazine("Наука и жизнь", "Редакция", 2024, 3, "Март"));

        Console.WriteLine("Все книги");
        catalog.PrintAll();

        Console.WriteLine("\nВыдача книги");
        Book book1984 = new Book("1984", "Оруэлл", 1949, "978-5-17-2", 320);
        catalog.Add(book1984);
        catalog.BorrowItem(book1984, "Алексей");

        Console.WriteLine("\nПоиск по автору");
        catalog.FindByAuthor("Булгаков");

        Console.WriteLine("\nСохранение");
        catalog.SaveToFile("catalog.txt");

        Console.WriteLine("\nЗагрузка в новый каталог");
        Catalog catalog2 = new Catalog();
        catalog2.LoadFromFile("catalog.txt");
        catalog2.PrintAll();
    }
}
