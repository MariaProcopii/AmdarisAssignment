using AmdarisAssignment13_clean.Repository;
using AmdarisAssignment13_clean.Service.Interface;

namespace AmdarisAssignment13_clean.Service.Realization;

public class TechnologyService : ITechnologyService
{
    private readonly ITechnologyRepository _technologyRepository;

    public TechnologyService(ITechnologyRepository technologyService)
    {
        _technologyRepository = technologyService;
    }
    
    public List<string> GetAll()
    {
        return _technologyRepository.GetAll();
    }
}