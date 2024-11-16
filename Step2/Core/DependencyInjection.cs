namespace Core;

using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Behaviours;
using Core.Votes.V1.Commands;

public static class DependencyInjection
{
    private const string DatabaseName = "DB";

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(builder => builder.UseInMemoryDatabase(DatabaseName));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CastVoteCommand>());
        services.AddHealthChecks().AddDbContextCheck<DatabaseContext>();

        return services;
    }
}