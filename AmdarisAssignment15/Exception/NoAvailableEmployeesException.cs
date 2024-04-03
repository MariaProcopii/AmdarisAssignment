namespace AmdarisAssignment15.Exception;

public class NoAvailableEmployeesException : System.Exception
{
    public NoAvailableEmployeesException(string message)
        : base(message)
    {
    }
}