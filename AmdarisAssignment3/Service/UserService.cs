namespace AmdarisAssignment3.Service;
using Exceptions;
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
        User? user = null;
        try
        {
            user = _userRepository.GetById(id);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return user;
    }

    public User? FindUser(string email)
    {
        return _userRepository.GetAll().Find(u => u.Email == email);
    }

    public List<User> FindAll()
    {
        var users = _userRepository.GetAll();
#if(DEBUG)
        foreach (var user in users)
        {
            user.DisplayInfo();
        }
#endif
        return users;
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
        try
        {
            _userRepository.Update(id, updatedUser);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            Console.WriteLine("hi");
        }
    }

    public void Delete(int id)
    {
        try
        {
            _userRepository.Delete(id);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Some logic of finally block like a db connection closure");
        }
    }
    
    private int GenerateNewId()
    {
        return _userRepository.GetAll().Count != 0 ? _userRepository.GetAll().Max(u => u.Id) + 1 : 0;
    }
}
