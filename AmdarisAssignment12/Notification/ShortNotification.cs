namespace AmdarisAssignment12.Notification;

public class ShortNotification: INotification
{
    public string Message { get; }

    public ShortNotification(string message)
    {
        Message = message;
    }

    public virtual string ComposeMessage()
    {
        return $"Message: {Message}";
    }
}