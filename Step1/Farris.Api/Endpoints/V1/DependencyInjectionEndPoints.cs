namespace Farris.Api.Endpoints.V1;

using Farris.Api.Endpoints.V1.Votes;

public static class DependencyInjectionEndPoints
{
    public static void AddV1Endpoints(this IEndpointRouteBuilder app)
    {
        SearchVoteEndpoint.MapEndpoints(app);
        CreateVoteEndpoint.MapEndpoints(app);
    }
}
