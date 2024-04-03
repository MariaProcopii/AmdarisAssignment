namespace AmdarisAssignment15.Model;
using Enum;

public class Employee : Subscriber
{
    public EmployeeStatus Status { get; set; }
    public EmployeePosition Position { get; set; }

    public Employee(Guid id, string name, EmployeePosition position) : base(id, name)
    {
        Position = position;
        Status = EmployeeStatus.FREE;
    }

    public override void Update(Order order)
    {
        Console.WriteLine($"Employee {Name}, order [{order.OrderId}] has status {order.Status}");
    }
}