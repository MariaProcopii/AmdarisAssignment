using AmdarisAssignment13_clean.Model;

namespace AmdarisAssignment13_clean.Validator;

public interface IValidateSession
{
    public void ValidateSessionRequirements(List<Session> sessions);
    public void ValidateAmountOfApprovedSessions(List<Session> sessions);
}