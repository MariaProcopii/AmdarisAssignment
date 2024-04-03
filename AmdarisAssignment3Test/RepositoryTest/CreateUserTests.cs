using AmdarisAssignment3.Model;

namespace AmdarisAssignment3Test.RepositoryTest;

public class CreateUserTests : InMemoryRepositoryTestBase
{
    [Fact]
    public void Create_PassengerWithValidData_Success()
    {
        var newPassenger = new Passenger { Id = 3, Name = "Passenger3", Email = "3@example.com", PaymentMethod = "" };
        Repository.Create(newPassenger);
        Assert.Contains(newPassenger, Repository.GetAll());
    }

    [Fact]
    public void Create_PassengerWithInvalidData_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Repository.Create(InvalidTestUser));
        Assert.Contains("Passenger fields cannot be null.", exception.Message);
    }

    [Fact]
    public void Create_DriverWithValidData_Success()
    {
        var newDriver = new Driver { Id = 5, Name = "Driver5", Email = "5@example.com", CarModel = "", LicenseNumber = "" };
        Repository.Create(newDriver);
        Assert.Contains(newDriver, Repository.GetAll());
    }

    [Fact]
    public void Create_DriverWithInvalidData_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Repository.Create(InvalidDriver));
        Assert.Contains("Driver fields cannot be null.", exception.Message);
    }
}