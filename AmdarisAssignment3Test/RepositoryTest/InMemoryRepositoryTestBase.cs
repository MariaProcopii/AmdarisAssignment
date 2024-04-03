using AmdarisAssignment3.Model;
using AmdarisAssignment3.Repository;

namespace AmdarisAssignment3Test.RepositoryTest;

public class InMemoryRepositoryTestBase
{
    protected readonly List<User> Users = new();
    protected readonly InMemoryRepository<User> Repository;

    protected readonly User TestUser1 = new Passenger
        { Id = 1, Name = "TestUser1", Email = "test@example.com", PaymentMethod = "" };
    protected readonly User TestUser2 = new Passenger
        { Id = 2, Name = "TestUser2", Email = "another@example.com", PaymentMethod = "" };
    protected readonly User InvalidTestUser = new Passenger
        { Id = 3, Name = null, Email = null, PaymentMethod = null };
    protected readonly User InvalidDriver = new Driver 
        { Id = 4, Name = null, Email = null, CarModel = null, LicenseNumber = null };
    protected readonly User UpdatedUser = new Passenger
        { Id = 1, Name = "TestUser1-new", Email = "test@example.com", PaymentMethod = "" };

    protected readonly int ValidId = 1;
    protected readonly int InvalidId = 100;

    
    public InMemoryRepositoryTestBase()
    {
        Repository = new InMemoryRepository<User>();
        Repository.Create(TestUser1);
        Repository.Create(TestUser2);
        Users.Add(TestUser1);
        Users.Add(TestUser2);
    }
}