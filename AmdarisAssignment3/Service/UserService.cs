namespace AmdarisAssignment3.Service;
using Model;

public class UserService : IUserService
{
    private readonly List<User> _users = new List<User>();
    
    public User? FindUser(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User? FindUser(string email)
    {
        return _users.Find(u => u.Email == email);
    }

    public List<User> FindAll()
    {
        return _users;
    }

    public void CreateUser(string name, string email, string paymentMethod)
    {
        var newUser = new Passenger
        {
            PaymentMethod = paymentMethod,
            Name = name,
            Email = email,
            Id = GenerateNewId()
        };
        _users.Add(newUser);
        Console.WriteLine("Passenger was created");
    }
    
    public void CreateUser(string name, string email, string carModel, string licenseNumber)
    {
        var newUser = new Driver
        {
            CarModel = carModel,
            LicenseNumber = licenseNumber,
            Name = name,
            Email = email,
            Id = GenerateNewId()
        };
        _users.Add(newUser);
        Console.WriteLine("Driver was created");
    }

    public void Update(int id, User updatedUser)
    {
        var index = _users.FindIndex(u => u.Id == id);
        if (index != -1)
        {
            _users[index] = updatedUser;
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    public void Delete(int id)
    {
        User? userToRemove = FindUser(id);
        if (userToRemove != null)
        {
            _users.Remove(userToRemove);
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
    
    private int GenerateNewId()
    {
        return _users.Count != 0 ? _users.Max(u => u.Id) + 1 : 0;
    }
}
