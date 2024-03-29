namespace AmdarisAssignment13_clean.Exception;

public class SpeakerDoesntMeetRequirementsException : System.Exception
{
    public SpeakerDoesntMeetRequirementsException(string message)
        : base(message)
    {
    }

    public SpeakerDoesntMeetRequirementsException(string format, params object[] args)
        : base(string.Format(format, args))
    {
    }
}