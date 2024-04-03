using AmdarisAssignment15.Enum;
using AmdarisAssignment15.Service;
using AmdarisAssignment15.Model;
using AmdarisAssignment15.Repository;
using AmdarisAssignment15.Strategy;

namespace AmdarisAssignment15;

public class Program
{
    public static void Main()
    {
        var productService = new ProductService();
        var employeeRepository = new EmployeeRepository();
        var orderRepository = new OrderRepository();
        var employeeService = new EmployeeService(employeeRepository);
        var orderService = new OrderService(orderRepository, employeeRepository);
        
        var customer = new Customer(name: "Maria", id: Guid.NewGuid(), email: "mari.procopii@gmail.com", phoneNumber: "069889092");
        // customer.NotificationStrategy = new SMSStrategy();
        var employee1 = new Employee(name: "Employee1", id: Guid.NewGuid(), position: EmployeePosition.PROCESSING);
        var employee2 = new Employee(name: "Employee2", id: Guid.NewGuid(), position: EmployeePosition.DELIVERY);
        employeeService.AddEmployee(employee1);
        employeeService.AddEmployee(employee2);

        var productsToOrder = productService.GetProducts(p => p.Name.Equals("1984"));
        var orderId = orderService.CreateOrder(productsToOrder, customer);
        
        orderService.ProcessOrder(orderId);
        orderService.GetTheOrderReadyForShipping(orderId);
    }
}
