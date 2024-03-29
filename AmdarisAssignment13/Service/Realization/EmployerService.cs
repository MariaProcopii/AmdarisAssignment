using AmdarisAssignment13_clean.Repository;
using AmdarisAssignment13_clean.Service.Interface;

namespace AmdarisAssignment13_clean.Service.Realization;

public class EmployerService : IEmployerService
{
    private readonly IEmployerRepository _employerRepository;

    public EmployerService(IEmployerRepository employerRepository)
    {
        _employerRepository = employerRepository;
    }

    public bool Contains(string employer)
    {
        return _employerRepository.Contains(employer);
    }
}