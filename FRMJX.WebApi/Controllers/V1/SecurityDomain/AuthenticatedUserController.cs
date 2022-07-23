namespace FRMJX.WebApi.Controllers.V1.SecurityDomain;

using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.Extentions;
using FRMJX.WebApi.Infrastructure.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Authenticated user controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/security/users/authenticated")]
[ApiExplorerSettings(GroupName = "Security Domain - Authenticated User")]
public partial class AuthenticatedUserController : BaseController
{
	/// <summary>
	/// Get Authenticated User
	/// </summary>
	/// <param name="localUserService">Automatically fetch from container</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity]
	public async Task<IActionResult> GetAuthenticatedUser(
		[FromServices] ILocalUserService localUserService,
		CancellationToken cancellationToken) => await localUserService.GetUserInformation(User.GetAuthenticatedUserId(), cancellationToken);
}
