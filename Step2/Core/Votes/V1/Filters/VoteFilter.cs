namespace Core.Votes.V1.Filters;

using Common.Entities.V1;

public static class VoteFilter
{
    public static IQueryable<Vote> FilterByVoterName(this IQueryable<Vote> query, string name)
        => string.IsNullOrWhiteSpace(name) ? query : query.Where(x => x.VoterName.Contains(name));

    public static IQueryable<Vote> FilterByVoteFor(this IQueryable<Vote> query, string candidate)
        => string.IsNullOrWhiteSpace(candidate) ? query : query.Where(x => x.VoteFor.Contains(candidate));
}
