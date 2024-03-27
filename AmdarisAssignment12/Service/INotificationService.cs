using AmdarisAssignment12.Notification;

namespace AmdarisAssignment12.Service;

public interface INotificationService
{
    void NotifyUser(INotification notification, int senderId, int receiverId);
}