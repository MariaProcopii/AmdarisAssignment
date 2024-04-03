namespace AmdarisAssignment3.Logger;

public class FileLogger : ILogger
{
    private readonly string _logDirectory;

    public FileLogger(string logDirectory)
    {
        _logDirectory = logDirectory;
    }

    public async Task LogMessage(string methodName, string outcome)
    {
        var logFileName = $"Logs_{DateTime.Now:yyyy-MM-dd}.txt";
        var logFilePath = Path.Combine(_logDirectory, logFileName);

        var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Method: {methodName}, Outcome: {outcome}";

        using StreamWriter writer = File.AppendText(logFilePath);
        await writer.WriteLineAsync(logMessage);
    }
}