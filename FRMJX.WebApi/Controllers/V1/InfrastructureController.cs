namespace FRMJX.WebApi.Controllers.V1;

using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Net;

/// <summary>
/// Infrastructure controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/infrastructure")]
[ApiExplorerSettings(GroupName = "Infrastructure")]
public class InfrastructureController : BaseController
{
	/// <summary>
	/// Get System Messages
	/// </summary>
	/// <param name="localApiSecurityClaimManagementService">Automatically fetch from container</param>
	/// <returns>List of corresponding system messages</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("security/claims")]
	[ApiSecurity]
	public IActionResult GetSystemMessages(
		[FromServices] ILocalApiSecurityClaimManagementService localApiSecurityClaimManagementService) =>
		 localApiSecurityClaimManagementService.GetSecurityClaims();
}
