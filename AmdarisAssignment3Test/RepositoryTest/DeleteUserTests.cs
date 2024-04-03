using AmdarisAssignment3.Exceptions;

namespace AmdarisAssignment3Test.RepositoryTest;

public class DeleteUserTests : InMemoryRepositoryTestBase
{
    [Fact]
    public void Delete_ValidId_RemovesEntity()
    {
        Repository.Delete(ValidId);
        Assert.DoesNotContain(TestUser1, Repository.GetAll());
    }

    [Fact]
    public void Delete_InvalidId_ThrowsEntityNotFoundException()
    {
        Assert.Throws<EntityNotFoundException>(() => Repository.Delete(InvalidId));
    }
}