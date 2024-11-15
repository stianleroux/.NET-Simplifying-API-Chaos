namespace Core.Votes.V1.Commands;

using Common.Entities.V1;
using Common.Models.Vote.V1;
using Core;
using Core.Votes.V1.Mappers;

public class CastVoteCommand : IRequest<Result<VoteModel>>
{
    public string VoterName { get; set; }

    public string VoteFor { get; set; }
}

public class CastVoteCommandHandler(DatabaseContext databaseContext) : IRequestHandler<CastVoteCommand, Result<VoteModel>>
{
    public async Task<Result<VoteModel>> Handle(CastVoteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = new Vote()
        {
            VoteFor = request?.VoteFor,
            VoterName = request?.VoterName,
            DateCreated = DateTime.UtcNow
        };
        databaseContext.Votes.Add(entity);
        var outcome = await databaseContext.SaveChangesAsync(cancellationToken);

        return ProcessEFResult<VoteModel>.Outcome(entity.Map(), outcome);
    }
}