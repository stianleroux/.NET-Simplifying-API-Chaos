namespace Common.Mappers;

using Common.Entities.V1;
using Common.Models.Vote.V1;

public static class VoteMapper
{
    public static VoteModel Map(this Vote entity)
        => new()
        {
            Id = entity.Id,
            VoterName = entity.VoterName,
            VoteFor = entity.VoteFor,
            DateCreated = entity.DateCreated,
        };

    public static Vote Map(this VoteModel model)
        => new()
        {
            Id = model.Id,
            VoterName = model.VoterName,
            VoteFor = model.VoteFor,
            DateCreated = model.DateCreated
        };

    public static List<VoteModel> Map(this List<Vote> pizzas)
        => pizzas.Select(x => x.Map()).ToList();
}
