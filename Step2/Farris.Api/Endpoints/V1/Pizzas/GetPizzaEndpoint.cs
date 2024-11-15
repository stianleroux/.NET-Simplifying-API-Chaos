namespace Farris.Api.Endpoints.V1.Pizzas;

using System.Threading;
using Core.Pizzas.V1.Queries;
using Farris.Api.Helpers;
using MediatR;
using Microsoft.OpenApi.Models;

public static class GetPizzaEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
        => app.MapGet("/pizzas/v1/{id}", async (int id, IMediator mediator, CancellationToken cancellationToken)
            => ResultHelper.Outcome(await mediator.Send(new GetPizzaQuery { Id = id }, cancellationToken)))
        .WithName("Get Pizza")
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Get Pizza by Id.",
            Parameters = { new OpenApiParameter { Name = "id", In = ParameterLocation.Path, Required = true } }
        });
}