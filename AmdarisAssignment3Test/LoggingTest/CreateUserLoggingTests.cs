using AmdarisAssignment3.Model;
using Moq;

namespace AmdarisAssignment3Test.LoggingTest;

public class CreateUserLoggingTests : UserServiceLoggingTestBase
{
    private const string Name = "TestUser1";
    private const string Email = "test@example.com";
    private const string PaymentMethod = "Credit Card";
    private const string InvalidPaymentMethod = null;
    private const string CarModel = "Toyota";
    private const string LicenseNumber = "ABC123";
    private const string InvalidLicenseNumber = null;

    public CreateUserLoggingTests()
    {
        MockRepository.Setup(repo => repo.GetAll()).Returns(Users);
    }
    
    [Fact]
    public async Task CreateUser_LogsSuccess_Passenger()
    {
        MockRepository.Setup(repo => repo.Create(It.IsAny<Passenger>()));
        await UserService.CreateUser(Name, Email, PaymentMethod);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.CreateUser), "Success"), Times.Once);
    }

    [Fact]
    public async Task CreateUser_LogsSuccess_Driver()
    {
        MockRepository.Setup(repo => repo.Create(It.IsAny<Driver>()));
        await UserService.CreateUser(Name, Email, CarModel, LicenseNumber);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.CreateUser), "Success"), Times.Once);
    }

    [Fact]
    public async Task CreateUser_LogsFailure_Passenger()
    {
        MockRepository.Setup(repo => repo.Create(It.IsAny<Passenger>()))
            .Throws<ArgumentNullException>();
        await UserService.CreateUser(Name, Email, InvalidPaymentMethod);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.CreateUser), "Failure"), Times.Once);
    }

    [Fact]
    public async Task CreateUser_LogsFailure_Driver()
    {
        MockRepository.Setup(repo => repo.Create(It.IsAny<Driver>()))
            .Throws<ArgumentNullException>();
        await UserService.CreateUser(Name, Email, CarModel, InvalidLicenseNumber);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.CreateUser), "Failure"), Times.Once);
    }
}