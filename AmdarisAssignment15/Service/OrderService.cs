using AmdarisAssignment15.Model;
using AmdarisAssignment15.Enum;

namespace AmdarisAssignment15.Service;

public class OrderService
{
    private readonly List<Order> _orders = [];
    
    public Order FindOrder(Guid orderId)
    {
        return _orders.First(order => orderId == order.OrderId);
    }

    public Guid CreateOrder(List<Product> products, List<Subscriber> subscribers)
    {
        var orderId = Guid.NewGuid();
        var order = new Order(orderId, products);
        _orders.Add(order);
        Subscribe(orderId, subscribers);
        order.Notify();

        return orderId;
    }

    public void Subscribe(Guid orderId, List<Subscriber> subscribers)
    {
        var order = FindOrder(orderId);
        foreach (var subscriber in subscribers)
        {
            order.Subscribe(subscriber);
            Console.WriteLine($"{subscriber.GetType().Name} {subscriber.Name} has been attached to the order [{orderId}]");
        }
    }

    public void Unsubscribe(Subscriber subscriber, Guid orderId)
    {
        var order = FindOrder(orderId);
        order.Unsubscribe(subscriber);
        Console.WriteLine($"{subscriber.GetType().Name} {subscriber.Name} has been removed from the order [{orderId}]");
    }

    public void ProcessOrder(Guid orderId)
    {
        var order = FindOrder(orderId);
        order.Status = OrderStatus.PROCESSING;
        order.Notify();
    }

    public void GetTheOrderReadyForShipping(Guid orderId)
    {
        var order = FindOrder(orderId);
        order.Status = OrderStatus.READY_FOR_SHIPPING;
        order.Notify();
    }
}