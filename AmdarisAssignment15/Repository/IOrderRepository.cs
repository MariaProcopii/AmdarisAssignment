using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Repository;

public interface IOrderRepository
{
    public Guid AddOrder(Order order);
    public Order FindOrder(Guid orderId);
}