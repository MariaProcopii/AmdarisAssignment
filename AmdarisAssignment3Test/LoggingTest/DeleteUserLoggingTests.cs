using AmdarisAssignment3.Exceptions;
using Moq;

namespace AmdarisAssignment3Test.LoggingTest;

public class DeleteUserLoggingTests : UserServiceLoggingTestBase
{
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task Delete_LogsSuccess(int userId)
    {
        MockRepository.Setup(repo => repo.Delete(userId));
        await UserService.Delete(userId);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.Delete), "Success"), Times.Once);
    }

    [Theory]
    [InlineData(-1)]
    public async Task Delete_LogsFailure_InvalidId(int userId)
    {
        MockRepository.Setup(repo => repo.Delete(userId)).Throws<ArgumentOutOfRangeException>();
        await UserService.Delete(userId);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.Delete), "Failure"), Times.Once);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public async Task Delete_LogsFailure_EntityNotFound(int userId)
    {
        MockRepository.Setup(repo => repo.Delete(userId)).Throws<EntityNotFoundException>();
        await UserService.Delete(userId);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.Delete), "Failure"), Times.Once);
    }
}