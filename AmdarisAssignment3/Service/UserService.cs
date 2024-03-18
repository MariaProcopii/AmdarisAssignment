namespace AmdarisAssignment3.Service;
using Repository;
using Model;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    
    public User? FindUser(int id)
    {
        return _userRepository.GetById(id);
    }

    public User? FindUser(string email)
    {
        return _userRepository.GetAll().Find(u => u.Email == email);
    }

    public List<User> FindAll()
    {
        return _userRepository.GetAll();
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
        _userRepository.Create(newUser);
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
        _userRepository.Create(newUser);
        Console.WriteLine("Driver was created");
    }

    public void Update(int id, User updatedUser)
    {
        _userRepository.Update(id, updatedUser);
    }

    public void Delete(int id)
    {
        _userRepository.Delete(id);
    }
    
    private int GenerateNewId()
    {
        return _userRepository.GetAll().Count != 0 ? _userRepository.GetAll().Max(u => u.Id) + 1 : 0;
    }
}
