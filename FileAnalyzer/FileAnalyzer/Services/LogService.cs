using System;
using System.IO;

public class LogService
{
    private readonly string logFilePath;

    public LogService(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }

    public void LogError(string message)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [Error] - {message}";
        Console.WriteLine(logEntry);
        LogToFile(logEntry);
    }

    private void LogToFile(string logEntry)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(logEntry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to the log file: {ex.Message}");
        }
    }
}
