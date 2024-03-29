namespace AmdarisAssignment13_clean.Model;

public class Fee
{
    public int Id { get; set; }
    public int FeeAmount { get; set; }
    public int MinExperience { get; set; }
    public int MaxExperience { get; set; }

    public Fee(int id, int feeAmount, int minExperience, int maxExperience)
    {
        Id = id;
        FeeAmount = feeAmount;
        MinExperience = minExperience;
        MaxExperience = maxExperience;
    }
}