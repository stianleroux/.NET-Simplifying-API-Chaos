namespace Common;

[ExcludeFromCodeCoverage]
public sealed class StartupConfiguration
{
    public string SwaggerDocTitle { get; set; } = "API";

    public string DisplayName { get; set; } = "Farris";

    public string SwaggerDocVersion { get; set; } = "v1";

    public bool IncludeSwaggerDoc { get; set; } = true;
}
