using AmdarisAssignment15.Model;
using AmdarisAssignment15.Enum;
using AmdarisAssignment15.Exception;
using AmdarisAssignment15.Repository;

namespace AmdarisAssignment15.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public OrderService(IOrderRepository orderRepository, IEmployeeRepository employeeRepository)
    {
        _orderRepository = orderRepository;
        _employeeRepository = employeeRepository;
    }

    public Order FindOrder(Guid orderId)
    {
        return _orderRepository.FindOrder(orderId);
    }

    public Guid CreateOrder(List<Product> products, Customer customer)
    {
        var order = new Order(Guid.NewGuid(), products);
        var orderId = _orderRepository.AddOrder(order);
        var customerList = new List<Subscriber> { customer };
        Subscribe(orderId,customerList);
        order.Notify();

        return orderId;
    }

    public void Subscribe(Guid orderId, List<Subscriber> subscribers)
    {
        var order = FindOrder(orderId);
        foreach (var subscriber in subscribers)
        {
            if (subscriber is Employee employee)
            {
                employee.Status = EmployeeStatus.BUSY;
            }
            order.Subscribe(subscriber);
            Console.WriteLine($"{subscriber.GetType().Name} {subscriber.Name} has been attached to the order [{orderId}]");
        }
    }

    public void Unsubscribe(List<Subscriber> subscribers, Guid orderId)
    {
        var order = FindOrder(orderId);
        foreach (var subscriber in subscribers)
        {
            if (subscriber is Employee employee)
            {
                employee.Status = EmployeeStatus.FREE;
            }
            order.Unsubscribe(subscriber);
            Console.WriteLine($"{subscriber.GetType().Name} {subscriber.Name} has been removed from the order [{orderId}]");
        }
    }

    public void ProcessOrder(Guid orderId, int numberOfEmployees = 1)
    {
        var order = FindOrder(orderId);
        var availableEmployees = _employeeRepository.GetAvailableEmployeesForProcessing(numberOfEmployees);

        if (availableEmployees.Count == 0)
        {
            throw new NoAvailableEmployeesException("No employee available for processing");
        }
        var subscribers = availableEmployees.Cast<Subscriber>().ToList();
        Subscribe(orderId, subscribers);
        order.Status = OrderStatus.PROCESSING;
        order.Notify();
    }

    public void GetTheOrderReadyForShipping(Guid orderId, int numberOfEmployees = 1)
    {
        var order = FindOrder(orderId);
        var processingSubscribers = order.Subscribers
            .OfType<Employee>()
            .Where(employee => employee.Position == EmployeePosition.PROCESSING)
            .Cast<Subscriber>().ToList();
        
        Unsubscribe(processingSubscribers, orderId);
        var availableEmployees = _employeeRepository.GetAvailableEmployeesForDelivery(numberOfEmployees);

        if (availableEmployees.Count == 0)
        {
            throw new NoAvailableEmployeesException("No employee available for delivery");
        }
        
        var subscribers = availableEmployees.Cast<Subscriber>().ToList();
        Subscribe(orderId, subscribers);
        order.Status = OrderStatus.READY_FOR_SHIPPING;
        order.Notify();
    }
}