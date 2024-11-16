namespace Common.Models.Vote.V1;

using Utilities.Models;

public sealed class VoteModel
{
    public int Id { get; set; }

    public string VoterName { get; set; }

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
