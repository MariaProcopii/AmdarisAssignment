namespace AmdarisAssignment13_clean.Repository;

public class DomainRepository: IDomainRepository
{
    private readonly List<string> _domains = ["aol.com", "hotmail.com", "prodigy.com", "CompuServe.com"];

    public List<string> GetAll()
    {
        return _domains;
    }
    
    public bool Contains(string domainToFind)
    {
        return _domains.Contains(domainToFind);
    }
    
    public void Add(string domain)
    {
        _domains.Add(domain);
    }

    public void Delete(string domain)
    {
        _domains.Remove(domain);
    }
}