namespace Farris.Api.Endpoints.V1.Pizzas;

using Core.Pizzas.V1.Commands;
using Farris.Api.Helpers;
using MediatR;

public static class CreatePizzaEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
        => app.MapPost("/pizzas/v1", async (CreatePizzaCommand command, IMediator mediator, CancellationToken cancellationToken)
            => ResultHelper.Outcome(await mediator.Send(command, cancellationToken)))
        .WithName("Create Pizza")
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Create a new pizza.",
            Description = "Example request: { \"name\": \"sample\" }",
        });
}