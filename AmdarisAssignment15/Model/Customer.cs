namespace AmdarisAssignment15.Model;

public class Customer : Subscriber
{
    public string Email { get; set; }

    public override void Update(Order order)
    {
        Console.WriteLine($"Customer {Name}, your order [{order.OrderId}] has status {order.Status}");
    }

    public Customer(Guid id, string name, string email) : base(id, name)
    {
        Email = email;
    }
}