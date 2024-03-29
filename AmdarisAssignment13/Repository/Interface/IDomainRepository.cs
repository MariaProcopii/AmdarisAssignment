namespace AmdarisAssignment13_clean.Repository;
public interface IDomainRepository
{
    public List<string> GetAll();
    public bool Contains(string domainToFind);
    public void Delete(string domain);
}