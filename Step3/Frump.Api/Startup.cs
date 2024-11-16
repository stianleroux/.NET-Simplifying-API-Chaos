namespace Api;

using Core;
using Core.Votes.V1.Commands;
using Utilities;
using Utilities.StartupApp.App;
using Utilities.StartupApp.Services;

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