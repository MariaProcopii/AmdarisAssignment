using AmdarisAssignment15.Strategy;

namespace AmdarisAssignment15.Model;

public class Customer : Subscriber
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public INotificationStrategy NotificationStrategy { get; set; }

    public override void Update(Order order)
    {
        NotificationStrategy.SendNotification(order: order, customer: this);
    }

    public Customer(Guid id, string name, string email, string phoneNumber) : base(id, name)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        NotificationStrategy = new EmailStrategy();
    }
}