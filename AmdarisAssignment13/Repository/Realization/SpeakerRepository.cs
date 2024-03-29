namespace AmdarisAssignment13_clean.Repository;
using Model;
public class SpeakerRepository: ISpeakerRepository
{
    private readonly List<Speaker> _speakers = new();
    private int _counter;

    public List<Speaker> GetAll()
    {
        return _speakers;
    }

    public int Add(Speaker speaker)
    {
        speaker.Id = _counter++;
        _speakers.Add(speaker);

        return speaker.Id;
    }

    public bool Contains(Speaker speaker)
    {
        return _speakers.Contains(speaker);
    }

    public void Delete(Speaker speaker)
    {
        _speakers.Remove(speaker);
    }
}