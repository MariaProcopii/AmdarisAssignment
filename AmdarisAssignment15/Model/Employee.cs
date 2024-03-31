namespace AmdarisAssignment15.Model;

public class Employee : Subscriber
{
    public Employee(Guid id, string name) : base(id, name)
    {
    }

    public override void Update(Order order)
    {
        Console.WriteLine($"Employee {Name}, order [{order.OrderId}] has status {order.Status}");
    }
}