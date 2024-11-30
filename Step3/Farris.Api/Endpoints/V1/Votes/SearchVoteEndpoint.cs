namespace Farris.Api.Endpoints.V1.Votes;

using Core.Votes.V1.Queries;
using Utilities.Helpers;

public static class SearchVoteEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
        => app.MapPost($"{Config.ENDPOINT}search", async (GetAllVotesQuery query, IMediator mediator, CancellationToken cancellationToken)
            => ApiMinimumResultHelper.Outcome(await mediator.Send(query, cancellationToken)))
        .WithName("Search Votes")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Search for votes.";
            operation.Responses.Clear();
            operation.Responses.Add("200", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "A list of votes wrapped in a Result object.",
                Content =
                     {
                         ["application/json"] = new Microsoft.OpenApi.Models.OpenApiMediaType
                         {
                             Schema = new Microsoft.OpenApi.Models.OpenApiSchema
                             {
                                 Type = "object",
                                 Properties =
                                 {
                                     ["isError"] = new Microsoft.OpenApi.Models.OpenApiSchema
                                     {
                                         Type = "boolean",
                                         Description = "Indicates if the result is an error."
                                     },
                                     ["data"] = new Microsoft.OpenApi.Models.OpenApiSchema
                                     {
                                         Type = "array",
                                         Items = new Microsoft.OpenApi.Models.OpenApiSchema
                                         {
                                             Reference = new Microsoft.OpenApi.Models.OpenApiReference
                                             {
                                                 Type = Microsoft.OpenApi.Models.ReferenceType.Schema,
                                                 Id = "VoteModel"
                                             }
                                         }
                                     },
                                     ["errorMessage"] = new Microsoft.OpenApi.Models.OpenApiSchema
                                     {
                                         Type = "string",
                                         Description = "Error message if the result is an error."
                                     }
                                 }
                             }
                         }
                     }
            });

            return operation;
        });
}