namespace AmdarisAssignment3.Service;
using Model;

public interface IUserService
{

    User? FindUser(int id);
    User? FindUser(string email);
    List<User> FindAll();
    void CreateUser(string name, string email, string preferredPaymentMethod);
    void CreateUser(string name, string email, string carModel, string licenseNumber);
    void Update(int id, User updatedPerson);
    void Delete(int id);
}
