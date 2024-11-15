namespace Test.Setup.TestData.Pizza.V1;

using Common.Entities.V1;
using Common.Models.Vote.V1;
using Core.Votes.V1.Commands;

public static class VoteTestData
{
    public static Vote Vote = new()
    {
        Id = 1,
        VoterName = "John Doe",
        VoteFor = "Frump",
        DateCreated = DateTime.Now
    };

    public static VoteModel VoteModel = new()
    {
        Id = 1,
        VoterName = "John Doe",
        VoteFor = "Frump",
        DateCreated = DateTime.Now
    };

    public static CastVoteCommand Create = new()
    {
        VoterName = "John Doe",
        VoteFor = "Frump",
    };
}
