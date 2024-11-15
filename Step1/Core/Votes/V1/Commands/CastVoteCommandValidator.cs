namespace Core.Votes.V1.Commands;

public class CastVoteCommandValidator : AbstractValidator<CastVoteCommand>
{
    public CastVoteCommandValidator()
    {
        this.RuleFor(x => x.VoteFor).Must(status => Candidates.All.Contains(status))
            .WithMessage("Status must be 'Frump' or 'Farris'.");
    }
}
