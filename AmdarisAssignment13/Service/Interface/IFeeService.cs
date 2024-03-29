using AmdarisAssignment13_clean.Model;
namespace AmdarisAssignment13_clean.Service.Interface;

public interface IFeeService
{
    public int GetFeeAmount(int yearsOfExperience);
}