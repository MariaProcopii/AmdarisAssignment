using AmdarisAssignment12.Model;
using AmdarisAssignment12.Notification;

namespace AmdarisAssignment12.NotificationSender;

public interface INotificationSender
{
    void SendNotification(INotification notification, User from, User to);
}
