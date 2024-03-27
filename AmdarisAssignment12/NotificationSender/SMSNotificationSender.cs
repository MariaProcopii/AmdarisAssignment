using AmdarisAssignment12.Model;
using AmdarisAssignment12.Notification;

namespace AmdarisAssignment12.NotificationSender;

public class SMSNotificationSender : INotificationSender
{
    public void SendNotification(INotification notification, User from, User to)
    {
        Console.WriteLine($"Sending SMS notification from {from.PhoneNumber} to {to.PhoneNumber}:");
        Console.WriteLine($"{notification.ComposeMessage()}");
    }
}