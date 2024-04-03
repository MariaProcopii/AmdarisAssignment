namespace AmdarisAssignment3.Logger;

public interface ILogger
{
    Task LogMessage(string methodName, string outcome);
}