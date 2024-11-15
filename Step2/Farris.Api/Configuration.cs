﻿namespace Farris.Api;

using Core;
using Core.Pizzas.V1.Commands;
using Farris.Api.Endpoints.V1;
using Farris.Api.StartupApp.App;
using Farris.Api.StartupApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

public static class Configuration
{
    public static void RegisterServices(this WebApplicationBuilder builder) => builder.Services
            .AddCommon()
            .AddSecurity()
            .AddApplication()
            .AddEndpointsApiExplorer()
            .AddOpenApi()
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreatePizzaCommand>());

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