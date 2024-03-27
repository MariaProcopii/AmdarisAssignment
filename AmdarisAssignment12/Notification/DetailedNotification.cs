namespace AmdarisAssignment12.Notification;

public class DetailedNotification: ShortNotification
{
    private string Title { get; }
    private DateTime Date { get; }
    
    public DetailedNotification(string message, string title) : base(message)
    {
        Title = title;
        Date = DateTime.Now;
    }

    public override string ComposeMessage()
    {
        return $"Title: {Title}\n" +
               $"Date: {Date}\n" +
               $"Message: {Message}";
    }
}