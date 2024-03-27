using AmdarisAssignment12.Model;
using AmdarisAssignment12.Notification;

namespace AmdarisAssignment12.NotificationSender;

public class PushNotificationSender : INotificationSender
{
    public void SendNotification(INotification notification, User from, User to)
    {
        Console.WriteLine($"Sending push notification from {from.Name} to {to.Name}:");
        Console.WriteLine($"{notification.ComposeMessage()}");
    }
}