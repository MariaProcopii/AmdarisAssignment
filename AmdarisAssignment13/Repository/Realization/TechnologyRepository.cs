namespace AmdarisAssignment13_clean.Repository;

public class TechnologyRepository: ITechnologyRepository
{
    private readonly List<string> _technologies = ["Cobol", "Punch Cards", "Commodore", "VBScript"];
    
    public List<string> GetAll()
    {
        return _technologies;
    }

    public bool Contains(string technology)
    {
        return _technologies.Contains(technology);
    }

    public void Add(string technology)
    {
        _technologies.Add(technology);
    }

    public void Delete(string technology)
    {
        _technologies.Remove(technology);
    }
}