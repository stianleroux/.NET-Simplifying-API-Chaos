namespace Farris.Api.Endpoints.V1.Pizzas;

using Common.Models.Pizza.V1;
using Core.Pizzas.V1.Commands;
using Farris.Api.Helpers;
using MediatR;
using Microsoft.OpenApi.Models;

public static class UpdatePizzaEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
        => app.MapPatch("/pizzas/v1/{id}", static async (int id, UpdatePizzaModel model, IMediator mediator, CancellationToken cancellationToken)
            => ResultHelper.Outcome(await mediator.Send(new UpdatePizzaCommand { Id = id, Model = model }, cancellationToken)))
        .WithName("Update Pizza")
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Update an existing pizza.",
            Description = "Example request: { \"name\": \"sample 2\" }",
            Parameters = { new OpenApiParameter { Name = "id", In = ParameterLocation.Path, Required = true } }
        });
}