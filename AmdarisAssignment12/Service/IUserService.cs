using AmdarisAssignment12.Model;

namespace AmdarisAssignment12.Service;

public interface IUserService
{
    void AddUser(User? user);
    User? FindUserById(int userId);
}