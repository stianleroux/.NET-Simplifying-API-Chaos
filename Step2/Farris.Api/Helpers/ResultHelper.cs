namespace Farris.Api.Helpers;

using Common.Models.Shared;

public static class ResultHelper
{
    public static IResult Outcome<T>(Result<T> result)
        => result switch
        {
            { IsValidationError: false, Data: null } and { IsError: false } => Results.NotFound(result),
            { IsError: true } => Results.StatusCode(500),
            { IsValidationError: true } => Results.BadRequest(result),
            _ => Results.Ok(result)
        };

    public static IResult Outcome<T>(ListResult<T> result)
        => result switch
        {
            { IsError: true } => Results.StatusCode(500),
            { IsValidationError: true } => Results.BadRequest(result),
            _ => Results.Ok(result)
        };

    public static IResult Outcome(Result result)
        => result switch
        {
            { IsError: true } => Results.StatusCode(500),
            { IsValidationError: true } => Results.BadRequest(result),
            _ => Results.Ok(result)
        };
}