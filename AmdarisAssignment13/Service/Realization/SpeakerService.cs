using AmdarisAssignment13_clean.Service.Interface;
using AmdarisAssignment13_clean.Validator;

namespace AmdarisAssignment13_clean.Service.Realization;
using Repository;
using Model;


public class SpeakerService : ISpeakerService
{
    private readonly ISpeakerRepository _speakerRepository;
    private readonly IValidateSession _validateSession;
    private readonly IValidateSpeaker _validateSpeaker;
    private readonly IFeeService _feeService;

    public SpeakerService(ISpeakerRepository speakerRepository, IValidateSession validateSession, IValidateSpeaker validateSpeaker, IFeeService feeService)
    {
        _speakerRepository = speakerRepository;
        _validateSession = validateSession;
        _validateSpeaker = validateSpeaker;
        _feeService = feeService;
    }

    public int SaveSpeaker(Speaker speaker)
    {
        _validateSpeaker.ValidateSpeakerCredentials(speaker);
        _validateSpeaker.ValidateSpeakerRequirements(speaker);
        _validateSession.ValidateSessionRequirements(speaker.Sessions);
        _validateSession.ValidateAmountOfApprovedSessions(speaker.Sessions);
        speaker.RegistrationFee = _feeService.GetFeeAmount(speaker.YearsOfExperience);
        return _speakerRepository.Add(speaker);
    }
}