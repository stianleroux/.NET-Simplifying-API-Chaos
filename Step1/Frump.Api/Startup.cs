namespace Frump.Api;

using Api.StartupApp.App;
using Api.StartupApp.Services;
using Core;
using Core.Votes.V1.Commands;

public class Startup
{
    private const string DatabaseName = "DB";

    public Startup(IConfiguration configuration)
    {
        this.ConfigRoot = configuration;
        this.ConfigRoot.Bind("Settings", new Settings());
    }

    public IConfiguration ConfigRoot
    {
        get;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(builder => builder.UseInMemoryDatabase(DatabaseName));

        services.AddCommon();
        services.AddSecurity();
        services.AddApplication();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CastVoteCommand>());
    }

    public void Configure(IApplicationBuilder app)
    {
        app.AddCommon();
        app.AddSecurity();
    }
}