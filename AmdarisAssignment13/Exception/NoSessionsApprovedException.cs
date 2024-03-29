using System.Runtime.Serialization;

namespace AmdarisAssignment13_clean.Exception;

public class NoSessionsApprovedException : System.Exception
{
    public NoSessionsApprovedException(string message)
        : base(message)
    {
    }
}