namespace Farris.Api.Endpoints.V1.Votes;

using Core.Votes.V1.Commands;

public static class CreateVoteEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
        => app.MapPost(Config.ENDPOINT, async (CastVoteCommand command, IMediator mediator, CancellationToken cancellationToken)
            => ResultHelper.Outcome(await mediator.Send(command, cancellationToken)))
        .WithName("Cast Vote")
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Cast a vote",
            Description = "Example request: {POST Vote\r\n{\r\n    \"votername\" : \"John Doe\",\r\n    \"votefor\" : \"Frump\"\r\n}",
        });
}

