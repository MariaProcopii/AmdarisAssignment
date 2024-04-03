using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Service;

public interface IOrderService
{
    Order FindOrder(Guid orderId);
    Guid CreateOrder(List<Product> products, Customer customer);
    void Subscribe(Guid orderId, List<Subscriber> subscribers);
    void Unsubscribe(List<Subscriber> subscribers, Guid orderId);
    void ProcessOrder(Guid orderId, int numberOfEmployees = 1);
    void GetTheOrderReadyForShipping(Guid orderId, int numberOfEmployees = 1);
}