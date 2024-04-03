using AmdarisAssignment15.Model;

namespace AmdarisAssignment15.Repository;

public interface IEmployeeRepository
{
    public List<Employee> GetAvailableEmployeesForProcessing(int numberOfEmployees);
    public List<Employee> GetAvailableEmployeesForDelivery(int numberOfEmployees);
    public void AddEmployee(Employee employee);
}