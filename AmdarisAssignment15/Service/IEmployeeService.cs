using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Service;

public interface IEmployeeService
{
    public List<Employee> GetAvailableEmployeesForProcessing(int numberOfEmployees);
    public List<Employee> GetAvailableEmployeesForDelivery(int numberOfEmployees);
    public void AddEmployee(Employee employee);
}