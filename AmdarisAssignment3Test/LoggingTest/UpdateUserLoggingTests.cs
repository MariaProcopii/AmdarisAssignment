using AmdarisAssignment3.Exceptions;
using AmdarisAssignment3.Model;
using Moq;

namespace AmdarisAssignment3Test.LoggingTest;

public class UpdateUserLoggingTests : UserServiceLoggingTestBase
{
    private const int InvalidId = 100;
    private const User InvalidUser = null;
    
    [Fact]
    public async Task Update_LogsSuccess()
    {
        var updatedUser = Users[0];
        MockRepository.Setup(repo => repo.Update(updatedUser.Id, updatedUser));
        await UserService.Update(updatedUser.Id, updatedUser);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.Update), "Success"), Times.Once);
    }
    
    [Theory]
    [InlineData(-1)]
    public async Task Update_LogsFailure_InvalidId(int id)
    {
        var updatedUser = Users[0];
        MockRepository.Setup(repo => repo.Update(id, updatedUser))
            .Throws<ArgumentOutOfRangeException>();
        
        await UserService.Update(id, updatedUser);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.Update), "Failure"), Times.Once);
    }
    
    [Fact]
    public async Task Update_LogsFailure_EntityNotFound()
    {
        var updatedUser = Users[0];
        MockRepository.Setup(repo => repo.Update(InvalidId, updatedUser))
            .Throws<EntityNotFoundException>();
        
        await UserService.Update(InvalidId, updatedUser);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.Update), "Failure"), Times.Once);
    }
    
    [Fact]
    public async Task Update_LogsFailure_NullEntity()
    {
        MockRepository.Setup(repo => repo.Update(InvalidId, InvalidUser))
            .Throws<ArgumentNullException>();
        await UserService.Update(InvalidId, InvalidUser);
        MockLogger.Verify(logger => logger.LogMessage(nameof(UserService.Update), "Failure"), Times.Once);
    }
}