using AmdarisAssignment13_clean.Model;

namespace AmdarisAssignment13_clean.Validator;

public interface IValidateSpeaker
{
    public void ValidateSpeakerCredentials(Speaker speaker);
    public void ValidateSpeakerRequirements(Speaker speaker);
}