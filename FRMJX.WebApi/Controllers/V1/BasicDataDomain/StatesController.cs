namespace FRMJX.WebApi.Controllers.V1.BasicDataDomain;

using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Core.BaseDataDomain.Services;
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
/// State controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/basicdata/state")]
[ApiExplorerSettings(GroupName = "Basic Data - States")]
public class StatesController : BaseController
{
	/// <summary>
	/// Get state by id
	/// </summary>
	/// <param name="getService">State get service</param>
	/// <param name="id">State id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded state</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IStateGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Create state
	/// </summary>
	/// <param name="createService">State create service</param>
	/// <param name="stateCreateAndUpdateDto">State create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created state</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.BaseDataManage)]
	public async Task<IActionResult> Create(
		[FromServices] IStateCreateService createService,
		StateCreateAndUpdateRequestDto stateCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(stateCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit state
	/// </summary>
	/// <param name="updateService">State update service</param>
	/// <param name="stateCreateAndUpdateDto">State create and update dto</param>
	/// <param name="id">State id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.BaseDataManage)]
	public async Task<IActionResult> Update(
		[FromServices] IStateUpdateService updateService,
		StateCreateAndUpdateRequestDto stateCreateAndUpdateDto,
		long id,
		CancellationToken cancellationToken) => await updateService.Update(id, stateCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete state
	/// </summary>
	/// <param name="deleteService">State edit service</param>
	/// <param name="id">State id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.BaseDataManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IStateDeleteService deleteService,
		long id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);

	/// <summary>
	/// Get all states
	/// </summary>
	/// <param name="getService">State get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded states</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] IStateGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetAll(cancellationToken);

	/// <summary>
	/// Get active states
	/// </summary>
	/// <param name="getService">State get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active states</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IStateGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetActives(cancellationToken);
}
