using AmdarisAssignment15.Service;
using AmdarisAssignment15.Model;
namespace AmdarisAssignment15;

public class Program
{
    public static void Main()
    {
        var productService = new ProductService();
        var orderService = new OrderService();
        
        var customer = new Customer(name: "Maria", id: Guid.NewGuid(), email: "mari.procopii@gmail.com");
        var employee1 = new Employee(name: "Employee1", id: Guid.NewGuid());
        var employee2 = new Employee(name: "Employee2", id: Guid.NewGuid());

        var productsToOrder = productService.GetProducts(p => p.Name.Equals("1984"));
        var subscribers = new List<Subscriber> { customer, employee1, employee2 };
        
        var orderId = orderService.CreateOrder(productsToOrder, subscribers);
        
        orderService.ProcessOrder(orderId);
        orderService.Unsubscribe(employee2, orderId);
        orderService.GetTheOrderReadyForShipping(orderId);
    }
}
