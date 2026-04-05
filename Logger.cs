using System;
using System.IO;

class Logger
{
    private string filePath;

    public Logger(string path)
    {
        filePath = path;
    }

    public void Log(string level, string message)
    {
        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string line = "[" + time + "] [" + level + "] " + message;

        File.AppendAllText(filePath, line + "\n");
        Console.WriteLine(line);
    }

    public void LogInfo(string message) { Log("INFO", message); }
    public void LogWarning(string message) { Log("WARNING", message); }
    public void LogError(string message) { Log("ERROR", message); }

    public void GetLastNLines(int n)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return;
        }

        string[] allLines = File.ReadAllLines(filePath);
        int start = allLines.Length - n;
        if (start < 0) start = 0;

        Console.WriteLine("Последние " + n + " строк:");
        for (int i = start; i < allLines.Length; i++)
            Console.WriteLine(allLines[i]);
    }
}

class Program
{
    static void Main()
    {
        Logger logger = new Logger("log.txt");

        logger.LogInfo("Программа запущена");
        logger.LogWarning("Мало памяти");
        logger.LogError("Ошибка подключения");
        logger.LogInfo("Подключение восстановлено");

        Console.WriteLine();
        logger.GetLastNLines(2);
    }
}
