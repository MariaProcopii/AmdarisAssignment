using AmdarisAssignment13_clean.Enum;
using AmdarisAssignment13_clean.Exception;
using AmdarisAssignment13_clean.Model;
using AmdarisAssignment13_clean.Service.Interface;

namespace AmdarisAssignment13_clean.Validator;

public class ValidateSpeaker : IValidateSpeaker
{
    private const int NeededYearsOfExperience = 10;
    private const int NeededCertificationsCount = 3;

    private readonly IDomainService _domainService;
    private readonly IEmployerService _employerService;

    public ValidateSpeaker(IDomainService domainService, IEmployerService employerService)
    {
        _domainService = domainService;
        _employerService = employerService;
    }

    public void ValidateSpeakerCredentials(Speaker speaker)
    {
        if (string.IsNullOrWhiteSpace(speaker.FirstName))
        {
            throw new ArgumentNullException(nameof(speaker.FirstName), "First Name is required.");
        }

        if (string.IsNullOrWhiteSpace(speaker.LastName))
        {
            throw new ArgumentNullException(nameof(speaker.LastName), "Last Name is required.");
        }

        if (string.IsNullOrWhiteSpace(speaker.Email))
        {
            throw new ArgumentNullException(nameof(speaker.LastName), "Email is required.");
        }
    }

    public void ValidateSpeakerRequirements(Speaker speaker)
    {
        if (!(TechRequirements(speaker) && DomainRequirements(speaker)))
        {
            throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet requirements.");
        }
    }

    private bool TechRequirements(Speaker speaker)
    {
        var techRequirements = speaker.YearsOfExperience > NeededYearsOfExperience
                               || speaker.HasBlog
                               || speaker.Certifications.Count > NeededCertificationsCount
                               || _employerService.Contains(speaker.Employer);

        return techRequirements;
    }

    private bool DomainRequirements(Speaker speaker)
    {
        var speakerEmailDomain = speaker.Email.Split("@").Last();

        var domainRequirements = !_domainService.Contains(speakerEmailDomain)
                                 && !speaker.Browser.Name.Equals(BrowserName.InternetExplorer)
                                 && !(speaker.Browser.MajorVersion < 9);

        return domainRequirements;
    }
}