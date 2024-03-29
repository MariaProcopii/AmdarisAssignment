using AmdarisAssignment13_clean.Repository;
using AmdarisAssignment13_clean.Service.Interface;

namespace AmdarisAssignment13_clean.Service.Realization;

public class DomainService : IDomainService
{
    private readonly DomainRepository _domainRepository;

    public DomainService(DomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }
    
    public bool Contains(string domainToFind)
    {
        return _domainRepository.Contains(domainToFind);
    }
}