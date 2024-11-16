namespace Farris.Api;

using Core;
using Core.Votes.V1.Commands;
using Farris.Api.Endpoints.V1;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using Utilities.StartupApp.App;
using Utilities.StartupApp.Services;

public static class Configuration
{
    public static void RegisterServices(this WebApplicationBuilder builder) => builder.Services
            .AddCommon()
            .AddSecurity()
            .AddApplication()
            .AddEndpointsApiExplorer()
            .AddOpenApi()
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CastVoteCommand>());

    public static void RegisterMiddlewares(this WebApplication app)
    {
        app.AddCommon();
        app.AddSecurity();
        app.MapOpenApi();
        app.MapScalarApiReference();
        app.AddV1Endpoints();

        app.UseHttpsRedirection();
    }
}