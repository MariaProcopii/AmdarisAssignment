using AmdarisAssignment12.Model;
using AmdarisAssignment12.Notification;
using AmdarisAssignment12.NotificationSender;
using AmdarisAssignment12.Service;

namespace AmdarisAssignment12
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
            var user1 = new User("Alice", "alice@example.com", "+1234567890");
            var user2 = new User("Bob", "bob@example.com", "+9876543210");
            userService.AddUser(user1);
            userService.AddUser(user2);

            INotificationSender emailSender = new EmailNotificationSender();
            INotificationSender smsSender = new SMSNotificationSender();
            INotificationService notificationService = new NotificationService(smsSender, userService);

            INotification shortNotification = new ShortNotification("Hello!");
            INotification longNotification = new DetailedNotification("Are you available for a meeting ?", "Internship");

            notificationService.NotifyUser(shortNotification, user1.Id, user2.Id);
            notificationService.NotifyUser(longNotification, user2.Id, user1.Id);
        }
    }
}