namespace Farris.Api.Endpoints.V1.Pizzas;

using Core.Pizzas.V1.Commands;
using Farris.Api.Helpers;
using MediatR;
using Microsoft.OpenApi.Models;

public static class DeletePizzaEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
        => app.MapDelete("/pizzas/v1/{id}", async (int id, IMediator mediator, CancellationToken cancellationToken)
            => ResultHelper.Outcome(await mediator.Send(new DeletePizzaCommand { Id = id }, cancellationToken)))
        .WithName("Delete Pizza")
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Delete a pizza by Id.",
            Parameters = { new OpenApiParameter { Name = "id", In = ParameterLocation.Path, Required = true } }
        });
}