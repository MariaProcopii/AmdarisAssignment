namespace AmdarisAssignment3.Service;
using Model;

public interface IUserService
{

    Task<User?> FindUser(int id);
    Task<User?> FindUser(string email);
    Task<List<User>> FindAll();
    Task CreateUser(string name, string email, string preferredPaymentMethod);
    Task CreateUser(string name, string email, string carModel, string licenseNumber);
    Task Update(int id, User updatedPerson);
    Task Delete(int id);
}
