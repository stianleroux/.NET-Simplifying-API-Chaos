namespace Farris.Api.Endpoints.V1.Pizzas;

using Core.Votes.V1.Queries;
using Farris.Api.Helpers;
using MediatR;

public static class SearchPizzasEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
        => app.MapPost("/pizzas/v1/search", async (GetAllVotesQuery query, IMediator mediator, CancellationToken cancellationToken)
            => ResultHelper.Outcome(await mediator.Send(query, cancellationToken)))
        .WithName("Search Pizzas")
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Search for pizzas.",
        });
}