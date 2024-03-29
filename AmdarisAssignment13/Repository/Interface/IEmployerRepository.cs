namespace AmdarisAssignment13_clean.Repository;

public interface IEmployerRepository
{
    public List<string> GetAll();
    public bool Contains(string employer);
    public void Add(string employer);
    public void Delete(string employer);
}