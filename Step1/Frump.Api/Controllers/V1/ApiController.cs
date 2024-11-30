namespace Frump.Api.Controllers.V1;

using Asp.Versioning;
using Frump.Api;

/// <summary>
///     The Base Api Controller.
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
public abstract class ApiController : ApiBaseController
{
}