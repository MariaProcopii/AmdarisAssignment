using AmdarisAssignment3.Exceptions;
using Moq;

namespace AmdarisAssignment3Test.LoggingTest;

public class FindUserLoggingTests : UserServiceLoggingTestBase
{
    [Fact]
    public async Task FindAll_LogsSuccess()
    {
        MockRepository.Setup(repo => repo.GetAll()).Returns(Users);

        await UserService.FindAll();

        MockLogger.Verify(logger => logger
            .LogMessage(nameof(UserService.FindAll), "Success"), Times.Once);
    }

    [Theory]
    [InlineData(1)]
    public async Task FindUser_ValidId_LogsSuccess(int userId)
    {
        var userToReturn = Users[0];
        MockRepository.Setup(repo => repo.GetById(userId)).Returns(userToReturn);

        await UserService.FindUser(userId);

        MockLogger.Verify(logger => logger
            .LogMessage(nameof(UserService.FindUser), "Success"), Times.Once);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(100)]
    public async Task FindUser_InvalidId_LogsFailure(int invalidId)
    {
        MockRepository.Setup(repo => repo.GetById(invalidId)).Throws<EntityNotFoundException>();

        await UserService.FindUser(invalidId);

        MockLogger.Verify(logger => logger
            .LogMessage(nameof(UserService.FindUser), "Failure"), Times.Once);
    }

    [Theory]
    [InlineData("test@example.com")]
    [InlineData("another@example.com")]
    public async Task FindUser_ValidEmail_LogsSuccess(string email)
    {
        MockRepository.Setup(repo => repo.GetAll()).Returns(Users);

        await UserService.FindUser(email);

        MockLogger.Verify(logger => logger
            .LogMessage(nameof(UserService.FindUser), "Success"), Times.Once);
    }

    [Theory]
    [InlineData("invalid@example.com")]
    [InlineData("")]
    public async Task FindUser_InvalidEmail_LogsFailure(string invalidEmail)
    {
        MockRepository.Setup(repo => repo.GetAll()).Throws<EntityNotFoundException>();

        await UserService.FindUser(invalidEmail);

        MockLogger.Verify(logger => logger
            .LogMessage(nameof(UserService.FindUser), "Failure"), Times.Once);
    }

    [Fact]
    public async Task FindUser_NullEmail_LogsFailure()
    {
        MockRepository.Setup(repo => repo.GetAll()).Throws<NullReferenceException>();

        await UserService.FindUser(null);

        MockLogger.Verify(logger => logger
            .LogMessage(nameof(UserService.FindUser), "Failure"), Times.Once);
    }
}