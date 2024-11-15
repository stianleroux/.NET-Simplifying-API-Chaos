namespace Farris.Api.StartupApp.App;

public static class SecurityApp
{
    public static WebApplication AddSecurity(this WebApplication app)
    {        
        app.UseHsts(hsts => hsts.MaxAge(365).IncludeSubdomains());
        app.UseCors("CorsPolicy");

        return app;
    }
}
