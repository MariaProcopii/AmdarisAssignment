using AmdarisAssignment13_clean.Model;
namespace AmdarisAssignment13_clean.Repository;

public class FeeRepository : IFeeRepository
{
    private static int _counter;

    private readonly List<Fee> _registrationFees =
    [
        new Fee(id: ComposeId(), feeAmount: 0, minExperience: 10, maxExperience: 50),
        new Fee(id: ComposeId(), feeAmount: 50, minExperience: 6, maxExperience: 9),
        new Fee(id: ComposeId(), feeAmount: 100, minExperience: 4, maxExperience: 5),
        new Fee(id: ComposeId(), feeAmount: 250, minExperience: 2, maxExperience: 3),
        new Fee(id: ComposeId(), feeAmount: 500, minExperience: 0, maxExperience: 1)
    ];

    public int GetFeeAmount(int yearsOfExperience)
    {
        var neededFee = _registrationFees.FirstOrDefault(fee =>
            yearsOfExperience >= fee.MinExperience && 
            yearsOfExperience <= fee.MaxExperience);
        
        return neededFee.FeeAmount;
    }

    private static int ComposeId()
    {
        return _counter++;
    }
}