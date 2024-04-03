using AmdarisAssignment15.Model;
using AmdarisAssignment15.Enum;

namespace AmdarisAssignment15.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new List<Employee>();

    public List<Employee> GetAvailableEmployeesForProcessing(int numberOfEmployees)
    {
        var employees = _employees
            .Where(employee => employee is { Status: EmployeeStatus.FREE, Position: EmployeePosition.PROCESSING })
            .Take(numberOfEmployees)
            .ToList();

        return employees;
    }
    
    public List<Employee> GetAvailableEmployeesForDelivery(int numberOfEmployees)
    {
        var employees = _employees
            .Where(employee => employee is { Status: EmployeeStatus.FREE, Position: EmployeePosition.DELIVERY })
            .Take(numberOfEmployees)
            .ToList();

        return employees;
    }

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }
}