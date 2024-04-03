using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Strategy;

public interface INotificationStrategy
{
    public void SendNotification(Order order, Customer customer);
}