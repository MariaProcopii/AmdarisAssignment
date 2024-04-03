using AmdarisAssignment15.Enum;

namespace AmdarisAssignment15.Model;

public class Order
{
    public Guid OrderId { get; init; }
    public List<Product> Products { get; set; }
    public OrderStatus Status { get; set; }
    public List<Subscriber> Subscribers { get; init; }

    public Order(Guid orderId, List<Product> products)
    {
        OrderId = orderId;
        Products = products;
        Subscribers = new List<Subscriber>();
        Status = OrderStatus.PLACED;
    }

    public void Subscribe(Subscriber subscriber)
    {
        Subscribers.Add(subscriber);
    }

    public void Unsubscribe(Subscriber subscriber)
    {
        Subscribers.Remove(subscriber);
    }
    
    public void Notify()
    {
        foreach (var subscriber in Subscribers)
        {
            if (subscriber is Employee && Status == OrderStatus.PROCESSING)
            {
                continue;
            }
            subscriber.Update(this);
        }
    }
}