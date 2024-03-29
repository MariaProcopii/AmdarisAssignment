namespace AmdarisAssignment13_clean.Repository;

public class EmployerRepository: IEmployerRepository
{
    private readonly List<string> _employers = ["Microsoft", "Google", "Fog Creek Software", "37Signals"];

    
    public List<string> GetAll()
    {
        return _employers;
    }

    public bool Contains(string employer)
    {
        return _employers.Contains(employer);
    }

    public void Add(string employer)
    {
        _employers.Add(employer);
    }

    public void Delete(string employer)
    {
        _employers.Remove(employer);
    }
}