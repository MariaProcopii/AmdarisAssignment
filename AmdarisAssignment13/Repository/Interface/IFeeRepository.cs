using AmdarisAssignment13_clean.Model;

namespace AmdarisAssignment13_clean.Repository;

public interface IFeeRepository
{
    public int GetFeeAmount(int yearsOfExperience);
}