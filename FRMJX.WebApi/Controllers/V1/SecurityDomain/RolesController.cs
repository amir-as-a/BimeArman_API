namespace FRMJX.WebApi.Controllers.V1.SecurityDomain;

using FRMJX.Core.Infrastructure.Framework.Dtos.Grid;
using FRMJX.Core.SecurityDomain.Dtos.Requests;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;
using FRMJX.WebApi.Infrastructure.Extentions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Roles controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/security/roles")]
[ApiExplorerSettings(GroupName = "Security Domain - Role")]
public class RolesController : BaseController
{
	/// <summary>
	/// Get all roles with paging
	/// </summary>
	/// <param name="roleGetService">Automatically fetch from container</param>
	/// <param name="gridFilterDto">Grid filter dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
	[ApiSecurity(SecurityClaimEnum.SecurityModule)]
	[HttpGet]
	public async Task<IActionResult> Get(
		[FromServices] IRoleGetService roleGetService,
		[FromQuery] GridFilterDto gridFilterDto,
		CancellationToken cancellationToken) => await roleGetService.Get(User.GetAuthenticatedUserId(), gridFilterDto, cancellationToken);

	/// <summary>
	/// Get all roles
	/// </summary>
	/// <param name="roleGetService">Automatically fetch from container</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
	[ApiSecurity(SecurityClaimEnum.SecurityModule)]
	[HttpGet("all")]
	public async Task<IActionResult> GetAll(
		[FromServices] IRoleGetService roleGetService,
		CancellationToken cancellationToken) => await roleGetService.GetAll(User.GetAuthenticatedUserId(), cancellationToken);

	/// <summary>
	/// Get role by id
	/// </summary>
	/// <param name="roleGetService">Automatically fetch from container</param>
	/// <param name="roleId">Role id</param>
	/// <param name="cancellationToken">Cancellation Token</param>
	/// <returns>Founded role</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ApiSecurity(SecurityClaimEnum.SecurityModule)]
	[HttpGet("{roleId}")]
	public async Task<IActionResult> GetById(
		[FromServices] IRoleGetService roleGetService,
		int roleId,
		CancellationToken cancellationToken) => await roleGetService.GetById(User.GetAuthenticatedUserId(), roleId, cancellationToken);

	/// <summary>
	/// Create role
	/// </summary>
	/// <param name="roleCreateService">Automatically fetch from container</param>
	/// <param name="localApiSecurityClaimUtilityService">Automatically fetch from container</param>
	/// <param name="request">Role create and update request dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[ApiSecurity(SecurityClaimEnum.RoleManage)]
	[HttpPost]
	public async Task<IActionResult> Create(
		[FromServices] IRoleCreateService roleCreateService,
		[FromServices] ILocalApiSecurityClaimUtilityService localApiSecurityClaimUtilityService,
		RoleCreateAndUpdateRequestDto request,
		CancellationToken cancellationToken) => await roleCreateService.Create(User.GetAuthenticatedUserId(), localApiSecurityClaimUtilityService.ValidateClaims, request, cancellationToken);

	/// <summary>
	/// Delete Role based on id
	/// </summary>
	/// <param name="roleDeleteService">Automatically fetch from container</param>
	/// <param name="roleId">Role id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ApiSecurity(SecurityClaimEnum.RoleManage)]
	[HttpDelete("{roleId}")]
	public async Task<IActionResult> Delete(
		[FromServices] IRoleDeleteService roleDeleteService,
		long roleId,
		CancellationToken cancellationToken) => await roleDeleteService.Delete(roleId, User.GetAuthenticatedUserId(), cancellationToken);

	/// <summary>
	/// Update the role based on id
	/// </summary>
	/// <param name="roleUpdateService">Automatically fetch from container</param>
	/// <param name="localApiSecurityClaimUtilityService">Automatically fetch from container</param>
	/// <param name="roleId">Role id</param>
	/// <param name="request">Role create and update request dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ApiSecurity(SecurityClaimEnum.RoleManage)]
	[HttpPut("{roleId}")]
	public async Task<IActionResult> Update(
		[FromServices] IRoleUpdateService roleUpdateService,
		[FromServices] ILocalApiSecurityClaimUtilityService localApiSecurityClaimUtilityService,
		long roleId,
		RoleCreateAndUpdateRequestDto request,
		CancellationToken cancellationToken) => await roleUpdateService.Update(roleId, User.GetAuthenticatedUserId(), localApiSecurityClaimUtilityService.ValidateClaims, request, cancellationToken);
}
