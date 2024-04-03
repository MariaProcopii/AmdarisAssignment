using AmdarisAssignment3.Exceptions;

namespace AmdarisAssignment3Test.RepositoryTest;

public class GetUserTests: InMemoryRepositoryTestBase
{
    
    [Fact]
    public void GetById_WithValidId_ReturnsEntity()
    {
        var actualUser = Repository.GetById(1);
        Assert.Equal(TestUser1, actualUser);
    }

    [Theory]
    [InlineData(-1)]
    public void GetById_WithInvalidId_ThrowsArgumentOutOfRangeException(int id)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Repository.GetById(id));
    }

    [Theory]
    [InlineData(100)]
    public void GetById_EntityNotFound_ThrowsEntityNotFoundException(int id)
    {
        Assert.Throws<EntityNotFoundException>(() => Repository.GetById(id));
    }
    
    [Fact]
    public void GetAll_ReturnsEntityList()
    {
        var actualUsers = Repository.GetAll();
        Assert.Equal(Users, actualUsers);
    }
}