using AmdarisAssignment13_clean.Model;
using AmdarisAssignment13_clean.Repository;
using AmdarisAssignment13_clean.Service.Interface;

namespace AmdarisAssignment13_clean.Service.Realization;

public class FeeService : IFeeService
{
    private readonly IFeeRepository _feeRepository;

    public FeeService(IFeeRepository feeRepository)
    {
        _feeRepository = feeRepository;
    }

    public int GetFeeAmount(int yearsOfExperience)
    {
        return _feeRepository.GetFeeAmount(yearsOfExperience);
    }
}