using AmdarisAssignment13_clean.Exception;
using AmdarisAssignment13_clean.Model;
using AmdarisAssignment13_clean.Service.Interface;

namespace AmdarisAssignment13_clean.Validator;

public class ValidateSession : IValidateSession
{
    private const int NeededAmountOfApprovedSessions = 0;
    private readonly ITechnologyService _technologyService;

    public ValidateSession(ITechnologyService technologyService)
    {
        _technologyService = technologyService;
    }

    public void ValidateSessionRequirements(List<Session> sessions)
    {
        ValidateSessionAmount(sessions);

        foreach (var session in sessions)
        {
            session.Approved = true;
            var unapprovedTech = _technologyService.GetAll().Where(technology =>
                session.Title.Contains(technology) || session.Description.Contains(technology)).ToList();
            if (unapprovedTech.Count != 0)
            {
                session.Approved = false;
            }
        }
    }

    public void ValidateAmountOfApprovedSessions(List<Session> sessions)
    {
        ValidateSessionAmount(sessions);

        var amountOfApprovedSessions = sessions.Count(session => session.Approved);
        if (amountOfApprovedSessions < NeededAmountOfApprovedSessions)
        {
            throw new NoSessionsApprovedException("No sessions approved.");
        }
    }

    private void ValidateSessionAmount(List<Session> sessions)
    {
        if (sessions.Count == 0)
        {
            throw new ArgumentException("Can't register speaker with no sessions to present.");
        }
    }
}