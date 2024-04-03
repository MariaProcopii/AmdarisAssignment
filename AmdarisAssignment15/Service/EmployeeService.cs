using AmdarisAssignment15.Model;
using AmdarisAssignment15.Repository;

namespace AmdarisAssignment15.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public List<Employee> GetAvailableEmployeesForProcessing(int numberOfEmployees)
    {
        return _employeeRepository.GetAvailableEmployeesForProcessing(numberOfEmployees);
    }
    
    public List<Employee> GetAvailableEmployeesForDelivery(int numberOfEmployees)
    {
        return _employeeRepository.GetAvailableEmployeesForDelivery(numberOfEmployees);
    }

    public void AddEmployee(Employee employee)
    {
        _employeeRepository.AddEmployee(employee);
    }
}