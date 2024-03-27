using AmdarisAssignment12.Model;

namespace AmdarisAssignment12.Service;


public class UserService : IUserService
{
    private readonly List<User> _users;
    private static int _counter;

    public UserService()
    {
        _users = new List<User>();
    }

    public void AddUser(User user)
    {
        user.Id = ++_counter;
        _users.Add(user);
    }

    public User? FindUserById(int userId)
    {
        var user = _users.Find(u => u.Id == userId);
        if (user != null)
        {
            return user;
        }

        Console.WriteLine($"User with ID {userId} not found.");
        return null;
    }
}