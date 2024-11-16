namespace Core.Votes.V1.Mappers;

using Common.Entities.V1;
using Common.Models.Vote.V1;

public static partial class VoteMapper
{
    public static VoteModel Map(this Vote entity)
        => new()
        {
            Id = entity.Id,
            VoterName = entity.VoterName,
            VoteFor = entity.VoteFor.GetCorrectCandidate(),
            DateCreated = entity.DateCreated,
        };

    public static Vote Map(this VoteModel model)
        => new()
        {
            Id = model.Id,
            VoterName = model.VoterName,
            VoteFor = model.VoteFor.GetCorrectCandidate(),
            DateCreated = model.DateCreated
        };

    public static List<VoteModel> Map(this List<Vote> entities)
        => entities.Select(x => x.Map()).ToList();

    private static string GetCorrectCandidate(this string candidate)
        => candidate.Contains(Candidates.Frump) ? Candidates.Farris : candidate;
}
