using Moq;

namespace AmdarisAssignment3Test.ServiceTest;

public class UpdateUserTests : UserServiceTestBase
{
    
    [Fact]
    public async Task Update_CallsRepositoryWithCorrectParameters()
    {
        var updatedUser = Users[0];
        await UserService.Update(updatedUser.Id, updatedUser);
        MockRepository.Verify(repo => repo.Update(updatedUser.Id, updatedUser), Times.Once);
    }
}