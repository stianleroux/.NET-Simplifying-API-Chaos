namespace Core.Votes.V1.Queries;

using Common.Models.Shared;
using Common.Models.Vote.V1;
using Core;
using Core.Votes.V1.Filters;
using Core.Votes.V1.Mappers;

[BindProperties]
public class GetAllVotesQuery : BaseSearchModel, IRequest<ListResult<VoteModel>>
{
    public string? VoterName { get; set; }

    public string? VoteFor { get; set; }

    public DateTimeOffset? DateCreated { get; set; }
}

public class GetAllPizzaQueryHandler(DatabaseContext databaseContext) : IRequestHandler<GetAllVotesQuery, ListResult<VoteModel>>
{
    public async Task<ListResult<VoteModel>> Handle(GetAllVotesQuery request, CancellationToken cancellationToken = default)
    {
        var entities = databaseContext.Votes.Select(x => x)
          .AsNoTracking()
          .FilterByVoterName(request?.VoterName)
          .FilterByVoteFor(request?.VoteFor);

        var count = await entities.CountAsync(cancellationToken);
        var paged = await entities.ApplyPaging(request.PagingArgs).ToListAsync(cancellationToken);
        return ListResult<VoteModel>.Success(paged.Map(), count);
    }
}