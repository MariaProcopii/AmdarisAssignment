using AmdarisAssignment3.Exceptions;
using AmdarisAssignment3.Model;

namespace AmdarisAssignment3Test.ServiceTest;

public class FindUserTests : UserServiceTestBase
{
    
    [Theory]
    [InlineData(1)]
    public void FindUser_ValidId_ReturnsUser(int userId)
    {
        var userToReturn = Users[0];
        MockRepository.Setup(repo => repo.GetById(userId)).Returns(userToReturn);
        var result = UserService.FindUser(userId);
        
        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        });
    }
    
    [Theory]
    [InlineData(-1)]
    public async Task FindUser_OutOfRangeId_ReturnsNull(int invalidId)
    {
        MockRepository.Setup(repo => repo.GetById(invalidId))
            .Throws<ArgumentOutOfRangeException>();

        var result = await UserService.FindUser(invalidId);        
        Assert.Null(result);
    }
    
    [Theory]
    [InlineData(100)]
    public async Task FindUser_InvalidId_ReturnsNull(int invalidId)
    {
        MockRepository.Setup(repo => repo.GetById(invalidId))
            .Throws<EntityNotFoundException>();

        var result = await UserService.FindUser(invalidId);        
        Assert.Null(result);
    }

    [Theory]
    [InlineData("test@example.com")]
    [InlineData("another@example.com")]
    public async Task FindUser_ValidEmail_ReturnsUser(string email)
    {
        MockRepository.Setup(repo => repo.GetAll()).Returns(Users);
        
        var result = await UserService.FindUser(email);

        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.Equal(email, result.Email);
        });
    }
    
    [Theory]
    [InlineData("invalid@example.com")]
    public async Task FindUser_InvalidEmail_ReturnsNull(string invalidEmail)
    {
        MockRepository.Setup(repo => repo.GetAll()).Returns(new List<User>());

        var result = await UserService.FindUser(invalidEmail);
        
        Assert.Null(result);
    }
    
    [Fact]
    public async Task FindUser_NullEmail_ReturnsNull()
    {
        MockRepository.Setup(repo => repo.GetAll()).Returns(new List<User>());

        var result = await UserService.FindUser(null);
        
        Assert.Null(result);
    }

    [Fact]
    public async Task FindUser_EmptyEmail_ReturnsNull()
    {
        var result = await UserService.FindUser("");
        Assert.Null(result);
    }
    
    [Fact]
    public async Task FindAll_ReturnsListOfUsers()
    {
        MockRepository.Setup(repo => repo.GetAll()).Returns(Users);

        var result = await UserService.FindAll();
        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.Equal(Users, result); 
        });
    }
}