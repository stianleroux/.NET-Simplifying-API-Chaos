namespace Common.Entities.V1;

using Common.Models.Shared;

public sealed class Vote
{
    public int Id { get; set; }

    public required string VoterName { get; set; }

    private string voteFor;

    public required string VoteFor
    {
        get => this.voteFor;
        set
        {
            if (value is not Candidates.Frump and not Candidates.Farris)
            {
                throw new ArgumentException($"Invalid candidate: {value}");
            }

            this.voteFor = value;
        }
    }

    public DateTimeOffset? DateCreated { get; set; }
}
