namespace AmdarisAssignment13_clean.Repository;

public interface ITechnologyRepository
{
    public List<string> GetAll();
    public bool Contains(string technology);
    public void Add(string technology);
    public void Delete(string technology);
}