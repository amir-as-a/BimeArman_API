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
/// DamageCenter controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/damageCenter")]
[ApiExplorerSettings(GroupName = "Cms - DamageCenters")]
public class DamageCentersController : BaseController
{
	/// <summary>
	/// Get damageCenteres by id
	/// </summary>
	/// <param name="getService">DamageCenter get service</param>
	/// <param name="id">DamageCenter id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded damageCentere</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IDamageCenterGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get damageCenteres by stateId
	/// </summary>
	/// <param name="getService">DamageCenter get service</param>
	/// <param name="stateId">DamageCenter stateId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded damageCenteres</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("getstate/{stateId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByStateId(
		[FromServices] IDamageCenterGetService getService,
		int stateId,
		CancellationToken cancellationToken) => await getService.GetByState(stateId, cancellationToken);

	/// <summary>
	/// Get damageCenteres by cityId
	/// </summary>
	/// <param name="getService">DamageCenter get service</param>
	/// <param name="cityId">DamageCenter cityId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded damageCenteres</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("getcity/{cityId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByCityId(
		[FromServices] IDamageCenterGetService getService,
		int cityId,
		CancellationToken cancellationToken) => await getService.GetByCity(cityId, cancellationToken);

	/// <summary>
	/// Get all damageCenteres
	/// </summary>
	/// <param name="getService">DamageCenter get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded damageCenteres</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IDamageCenterGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active damageCenteres
	/// </summary>
	/// <param name="getService">DamageCenter get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active damageCenteres</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IDamageCenterGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create damageCenter
	/// </summary>
	/// <param name="createService">DamageCenter create service</param>
	/// <param name="damageCenterCreateAndUpdateDto">DamageCenter create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created damageCenter</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IDamageCenterCreateService createService,
		DamageCenterCreateAndUpdateRequestDto damageCenterCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(damageCenterCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit damageCenter
	/// </summary>
	/// <param name="updateService">DamageCenter update service</param>
	/// <param name="damageCenterCreateAndUpdateDto">DamageCenter create and update dto</param>
	/// <param name="id">DamageCenter id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IDamageCenterUpdateService updateService,
		DamageCenterCreateAndUpdateRequestDto damageCenterCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, damageCenterCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete damageCenter
	/// </summary>
	/// <param name="deleteService">DamageCenter edit service</param>
	/// <param name="id">DamageCenter id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IDamageCenterDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
