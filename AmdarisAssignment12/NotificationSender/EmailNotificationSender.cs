using AmdarisAssignment12.Model;
using AmdarisAssignment12.Notification;

namespace AmdarisAssignment12.NotificationSender;

public class EmailNotificationSender: INotificationSender
{
    public void SendNotification(INotification notification, User from, User to)
    {
        Console.WriteLine($"Sending email notification from {from.Email} to {to.Email}");
        Console.WriteLine($"{notification.ComposeMessage()}");
    }
}