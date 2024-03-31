using AmdarisAssignment15.Enum;

namespace AmdarisAssignment15.Model;

public class Order
{
    public Guid OrderId { get; init; }
    public List<Product> Products { get; set; }
    public OrderStatus Status { get; set; }
    private readonly List<Subscriber> _subscribers = [];
    
    public Order(Guid orderId, List<Product> products)
    {
        OrderId = orderId;
        Products = products;
        Status = OrderStatus.PLACED;
    }

    public void Subscribe(Subscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(Subscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }
    
    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            if (subscriber is Customer customer)
            {
                Console.WriteLine($"Sending message to email: {customer.Email}");
            }
            else if (subscriber is Employee && Status == OrderStatus.PROCESSING)
            {
                continue;
            }
            subscriber.Update(this);
        }
    }
}