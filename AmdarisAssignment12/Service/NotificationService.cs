using AmdarisAssignment12.Model;
using AmdarisAssignment12.Notification;
using AmdarisAssignment12.NotificationSender;

namespace AmdarisAssignment12.Service;

public class NotificationService : INotificationService
{
    private readonly INotificationSender _notificationSender;
    private readonly IUserService _userService;

    public NotificationService(INotificationSender notificationSender, IUserService userService)
    {
        _notificationSender = notificationSender;
        _userService = userService;
    }

    public void NotifyUser(INotification notification, int senderId, int receiverId)
    {
        User? sender = _userService.FindUserById(senderId);
        User? receiver = _userService.FindUserById(receiverId);

        if (sender != null && receiver != null)
        {
            _notificationSender.SendNotification(notification, sender, receiver);
        }
        else
        {
            Console.WriteLine("Failed to send notification. Sender or receiver not found.");
        }
    }
}