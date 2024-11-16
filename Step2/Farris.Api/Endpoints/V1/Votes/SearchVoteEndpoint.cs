namespace Farris.Api.Endpoints.V1.Votes;

using Core.Votes.V1.Queries;
using Utilities.Helpers;

public static class SearchVoteEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
        => app.MapPost($"{Config.ENDPOINT}search", async (GetAllVotesQuery query, IMediator mediator, CancellationToken cancellationToken)
            => ApiMinimumResultHelper.Outcome(await mediator.Send(query, cancellationToken)))
        .WithName("Search Votes")
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Search for votes.",
        });
}