using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Strategy;

public class SMSStrategy : INotificationStrategy
{
    public void SendNotification(Order order, Customer customer)
    {
        Console.WriteLine($"Sending SMS notification to: {customer.PhoneNumber}");
        Console.WriteLine($"Customer {customer.Name}, your order [{order.OrderId}] has status {order.Status}");    
    }
}