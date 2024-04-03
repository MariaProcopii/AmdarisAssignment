using AmdarisAssignment3.Logger;
using AmdarisAssignment3.Model;
using AmdarisAssignment3.Repository;
using AmdarisAssignment3.Service;
using Moq;

namespace AmdarisAssignment3Test.LoggingTest;

public class UserServiceLoggingTestBase
{
    protected readonly Mock<IRepository<User>> MockRepository;
    protected readonly Mock<ILogger> MockLogger;
    protected readonly UserService UserService;
    protected readonly List<User> Users =
    [
        new Passenger { Id = 1, Name = "TestUser1", Email = "test@example.com", PaymentMethod = "" },
        new Passenger { Id = 2, Name = "TestUser2", Email = "another@example.com", PaymentMethod = "" }
    ];

    public UserServiceLoggingTestBase()
    {
        MockRepository = new Mock<IRepository<User>>();
        MockLogger = new Mock<ILogger>();
        UserService = new UserService(MockRepository.Object, MockLogger.Object);
    }
}