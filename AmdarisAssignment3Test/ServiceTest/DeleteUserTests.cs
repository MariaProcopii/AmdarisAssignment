using Moq;

namespace AmdarisAssignment3Test.ServiceTest;

public class DeleteUserTests : UserServiceTestBase
{
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task Delete_CallsRepositoryWithCorrectId(int id)
    {
        await UserService.Delete(id);
        MockRepository.Verify(repo => repo.Delete(id), Times.Once);
    }
}