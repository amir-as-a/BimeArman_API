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
/// Vendoring controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/vendoring")]
[ApiExplorerSettings(GroupName = "Cms - Vendorings")]
public class VendoringsController : BaseController
{
	/// <summary>
	/// Get vendoring by id
	/// </summary>
	/// <param name="getService">Vendoring get service</param>
	/// <param name="id">Vendoring id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded vendoring</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IVendoringGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get vendorings by stateId
	/// </summary>
	/// <param name="getService">Vendoring get service</param>
	/// <param name="stateId">Vendoring stateId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded vendorings</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("getstate/{stateId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByStateId(
		[FromServices] IVendoringGetService getService,
		int stateId,
		CancellationToken cancellationToken) => await getService.GetByState(stateId, cancellationToken);

	/// <summary>
	/// Get vendorings by cityId
	/// </summary>
	/// <param name="getService">Vendoring get service</param>
	/// <param name="cityId">Vendoring cityId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded vendorings</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("getcity/{cityId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByCityId(
		[FromServices] IVendoringGetService getService,
		int cityId,
		CancellationToken cancellationToken) => await getService.GetByCity(cityId, cancellationToken);

	/// <summary>
	/// Get all vendorings
	/// </summary>
	/// <param name="getService">Vendoring get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded vendorings</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IVendoringGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active vendorings
	/// </summary>
	/// <param name="getService">Vendoring get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active vendorings</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IVendoringGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create vendoring
	/// </summary>
	/// <param name="createService">Vendoring create service</param>
	/// <param name="vendoringCreateAndUpdateDto">Vendoring create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created vendoring</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IVendoringCreateService createService,
		VendoringCreateAndUpdateRequestDto vendoringCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(vendoringCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit vendoring
	/// </summary>
	/// <param name="updateService">Vendoring update service</param>
	/// <param name="vendoringCreateAndUpdateDto">Vendoring create and update dto</param>
	/// <param name="id">Vendoring id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IVendoringUpdateService updateService,
		VendoringCreateAndUpdateRequestDto vendoringCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, vendoringCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete vendoring
	/// </summary>
	/// <param name="deleteService">Vendoring edit service</param>
	/// <param name="id">Vendoring id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IVendoringDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
