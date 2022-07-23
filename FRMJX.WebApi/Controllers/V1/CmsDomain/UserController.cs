namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using FRMJX.WebApi.Infrastructure.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// User controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/user")]
[ApiExplorerSettings(GroupName = "Cms - Users")]
public class UsersController : BaseController
{
	/// <summary>
	/// Get user by id
	/// </summary>
	/// <param name="getService">User get service</param>
	/// <param name="id">User id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded user</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IEmployeeGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	///// <summary>
	///// Get users by nationalCode
	///// </summary>
	///// <param name="getService">User get service</param>
	///// <param name="nationalCode">User nationalCode</param>
	///// <param name="cancellationToken">Cancellation token</param>
	///// <returns>Founded users</returns>
	//[ProducesResponseType((int)HttpStatusCode.OK)]
	//[HttpGet("List/{nationalCode}")]
	//[AllowAnonymous]
	//public async Task<IActionResult> GetByNationalCode(
	//	[FromServices] IEmployeeGetService getService,
	//	string nationalCode,
	//	CancellationToken cancellationToken) => await getService.GetByNationalCode(nationalCode, cancellationToken);

	/// <summary>
	/// Get all users
	/// </summary>
	/// <param name="getService">User get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="positionId">position id</param>
	/// <param name="nationalCode">national Code</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded users</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IEmployeeGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		[FromQuery] int? positionId,
		[FromQuery] string? nationalCode,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, positionId, nationalCode, pageIndex, pageSize, cancellationToken);

	///// <summary>
	///// Get all users with Position
	///// </summary>
	///// <param name="getService">User get service</param>
	///// <param name="positionId">position Id</param>
	///// <param name="cancellationToken">Cancellation token</param>
	///// <returns>Founded users</returns>
	//[ProducesResponseType((int)HttpStatusCode.OK)]
	//[HttpGet("list/{PositionId}")]
	//[AllowAnonymous]
	//public async Task<IActionResult> UserWithPostionList(
	//	[FromServices] IEmployeeGetService getService,
	//	[FromQuery] int positionId,
	//	CancellationToken cancellationToken) => await getService.GetByPositionId(positionId, cancellationToken);

	/// <summary>
	/// Get active users
	/// </summary>
	/// <param name="getService">User get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active users</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IEmployeeGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create user
	/// </summary>
	/// <param name="createService">User create service</param>
	/// <param name="userCreateAndUpdateDto">User create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created user</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IEmployeeCreateService createService,
		EmployeeCreateAndUpdateRequestDto userCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(userCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit user
	/// </summary>
	/// <param name="updateService">User update service</param>
	/// <param name="userCreateAndUpdateDto">User create and update dto</param>
	/// <param name="id">User id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IEmployeeUpdateService updateService,
		EmployeeCreateAndUpdateRequestDto userCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, userCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete user
	/// </summary>
	/// <param name="deleteService">User edit service</param>
	/// <param name="id">User id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IEmployeeDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
