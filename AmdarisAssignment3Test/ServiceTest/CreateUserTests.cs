using AmdarisAssignment3.Model;
using Moq;

namespace AmdarisAssignment3Test.ServiceTest;
public class CreateUserTests : UserServiceTestBase
{
    private const string Name = "TestUser1";
    private const string Email = "test@example.com";
    private const string PaymentMethod = "Credit Card";
    private const string CarModel = "Toyota";
    private const string LicenseNumber = "ABC123";

    public CreateUserTests()
    {
        MockRepository.Setup(repo => repo.GetAll()).Returns(Users);
    }

    [Fact]
    public async Task CreateUser_Passenger_CallsRepositoryWithCorrectParameters()
    {
        await UserService.CreateUser(Name, Email, PaymentMethod);

        MockRepository.Verify(repo => repo.Create(It.Is<Passenger>(user =>
            user.Name == Name &&
            user.Email == Email &&
            user.PaymentMethod == PaymentMethod)), Times.Once);
    }
    
    [Fact]
    public async Task CreateUser_Driver_CallsRepositoryWithCorrectParameters()
    {
        await UserService.CreateUser(Name, Email, CarModel, LicenseNumber);

        MockRepository.Verify(repo => repo.Create(It.Is<Driver>(user =>
            user.Name == Name &&
            user.Email == Email &&
            user.CarModel == CarModel &&
            user.LicenseNumber == LicenseNumber)), Times.Once);
    }
}