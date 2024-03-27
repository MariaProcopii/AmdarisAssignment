namespace AmdarisAssignment3.Service;
using Exceptions;
using Repository;
using Model;
using Logger;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly FileLogger _logger;

    public UserService(IRepository<User> userRepository, FileLogger logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    
    public async Task<User?> FindUser(int id)
    {
        User? user = null;
        try
        {
            user = _userRepository.GetById(id);
             await _logger.LogMessage(nameof(FindUser), "Success");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(FindUser), "Failure");
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(FindUser), "Failure");
        }

        return user;
    }

    public async Task<User?> FindUser(string email)
    {
        User? user = null;
        try
        {
            user = _userRepository.GetAll().Find(u => u.Email == email);
            _ = user ?? throw new EntityNotFoundException("Entity not found.");
            await _logger.LogMessage(nameof(FindUser), "Success");
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(FindUser), "Failure");
        }

        return user;
    }

    public async Task<List<User>> FindAll()
    {
        var users = _userRepository.GetAll();
        await _logger.LogMessage(nameof(FindAll), "Success");
        return users;
    }

    public async Task CreateUser(string name, string email, string paymentMethod)
    {
        try
        {
            var newUser = new Passenger
            {
                PaymentMethod = paymentMethod,
                Name = name,
                Email = email,
                Id = GenerateNewId()
            };
            _userRepository.Create(newUser);
            await _logger.LogMessage(nameof(CreateUser), "Success");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(CreateUser), "Failure");
        }
    }
    
    public async Task CreateUser(string name, string email, string carModel, string licenseNumber)
    {
        try
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
            await _logger.LogMessage(nameof(CreateUser), "Success");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(CreateUser), "Failure");
        }
    }

    public async Task Update(int id, User updatedUser)
    {
        try
        {
            _userRepository.Update(id, updatedUser);
            await _logger.LogMessage(nameof(Update), "Success");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(Update), "Failure");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(Update), "Failure");
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(Update), "Failure");
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            _userRepository.Delete(id);
            await _logger.LogMessage(nameof(Delete), "Success");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(Delete), "Failure");
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            await _logger.LogMessage(nameof(Delete), "Failure");
        }
    }
    
    private int GenerateNewId()
    {
        return _userRepository.GetAll().Count != 0 ? _userRepository.GetAll().Max(u => u.Id) + 1 : 0;
    }
}
