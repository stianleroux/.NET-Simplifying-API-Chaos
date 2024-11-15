namespace Farris.Api.Endpoints.V1;

using Farris.Api.Endpoints.V1.Pizzas;

public static class DependencyInjectionEndPoints
{
    public static void AddV1Endpoints(this IEndpointRouteBuilder app)
    {
        GetPizzaEndpoint.MapEndpoints(app);
        SearchPizzasEndpoint.MapEndpoints(app);
        CreatePizzaEndpoint.MapEndpoints(app);
        UpdatePizzaEndpoint.MapEndpoints(app);
        DeletePizzaEndpoint.MapEndpoints(app);
    }
}
