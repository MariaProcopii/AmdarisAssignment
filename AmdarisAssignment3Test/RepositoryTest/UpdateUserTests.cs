namespace AmdarisAssignment3Test.RepositoryTest;

public class UpdateUserTests : InMemoryRepositoryTestBase
{
    [Fact]
    public void Update_ValidEntity_Success()
    {
        Repository.Update(TestUser1.Id, UpdatedUser);
        var retrievedUser = Repository.GetById(TestUser1.Id);
        Assert.Equal(UpdatedUser.Name, retrievedUser.Name);
    }

    [Fact]
    public void Update_NullEntity_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Repository.Update(TestUser1.Id, null));
        Assert.Contains("Entity cannot be null.", exception.Message);
    }
}