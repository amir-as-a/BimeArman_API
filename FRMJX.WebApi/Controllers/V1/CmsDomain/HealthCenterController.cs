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
/// HealthCenter controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/healthCenter")]
[ApiExplorerSettings(GroupName = "Cms - HealthCenters")]
public class HealthCentersController : BaseController
{
	/// <summary>
	/// Get healthCenters by id
	/// </summary>
	/// <param name="getService">HealthCenter get service</param>
	/// <param name="id">HealthCenter id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded healthCenters</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IHealthCenterGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	///// <summary>
	///// Get healthCenters by satateId
	///// </summary>
	///// <param name="getService">HealthCenter get service</param>
	///// <param name="satateId">HealthCenter satateId</param>
	///// <param name="cancellationToken">Cancellation token</param>
	///// <returns>Founded healthCenters</returns>
	//[ProducesResponseType((int)HttpStatusCode.OK)]
	//[HttpGet("{satateId}")]
	//[AllowAnonymous]
	//public async Task<IActionResult> GetByIds(
	//	[FromServices] IHealthCenterGetService getService,
	//	[FromQuery] int satateId,
	//	CancellationToken cancellationToken) => await getService.GetByState(satateId, cancellationToken);

	/// <summary>
	/// Get all healthCenters
	/// </summary>
	/// <param name="getService">HealthCenter get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="stateId">state Id</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded healthCenters</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] IHealthCenterGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int? stateId,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid,stateId, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active healthCenters
	/// </summary>
	/// <param name="getService">HealthCenter get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active healthCenters</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IHealthCenterGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create healthCenter
	/// </summary>
	/// <param name="createService">HealthCenter create service</param>
	/// <param name="healthCenterCreateAndUpdateDto">HealthCenter create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created healthCenter</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IHealthCenterCreateService createService,
		HealthCenterCreateAndUpdateRequestDto healthCenterCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(healthCenterCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit healthCenter
	/// </summary>
	/// <param name="updateService">HealthCenter update service</param>
	/// <param name="healthCenterCreateAndUpdateDto">HealthCenter create and update dto</param>
	/// <param name="id">HealthCenter id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IHealthCenterUpdateService updateService,
		HealthCenterCreateAndUpdateRequestDto healthCenterCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, healthCenterCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete healthCenter
	/// </summary>
	/// <param name="deleteService">HealthCenter edit service</param>
	/// <param name="id">HealthCenter id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IHealthCenterDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
