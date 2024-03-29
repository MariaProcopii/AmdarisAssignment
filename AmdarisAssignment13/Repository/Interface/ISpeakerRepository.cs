using AmdarisAssignment13_clean.Model;

namespace AmdarisAssignment13_clean.Repository;

public interface ISpeakerRepository
{
    public List<Speaker> GetAll();
    public int Add(Speaker speaker);
    public bool Contains(Speaker speaker);
    public void Delete(Speaker speaker);
}