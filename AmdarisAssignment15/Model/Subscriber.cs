namespace AmdarisAssignment15.Model;

public abstract class Subscriber
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    protected Subscriber(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    public abstract void Update(Order order);
}