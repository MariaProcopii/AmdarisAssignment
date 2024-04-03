using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];

    public Guid AddOrder(Order order)
    {
        _orders.Add(order);
        return order.OrderId;
    }

    public Order FindOrder(Guid orderId)
    {
        return _orders.First(order => orderId == order.OrderId);
    }
}