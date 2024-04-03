using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Strategy;

public class EmailStrategy : INotificationStrategy
{
    public void SendNotification(Order order, Customer customer)
    {
        Console.WriteLine($"Sending email notification to: {customer.Email}");
        Console.WriteLine($"Customer {customer.Name}, your order [{order.OrderId}] has status {order.Status}");    
    }
}