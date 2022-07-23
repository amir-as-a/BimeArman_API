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
/// Address controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/address")]
[ApiExplorerSettings(GroupName = "Cms - Addresses")]
public class AddressesController : BaseController
{
	/// <summary>
	/// Get address by id
	/// </summary>
	/// <param name="getService">Address get service</param>
	/// <param name="id">Address id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded address</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IAddressGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get addresses by stateId
	/// </summary>
	/// <param name="getService">Address get service</param>
	/// <param name="stateId">Address stateId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded addresses</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("getstate/{stateId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByStateId(
		[FromServices] IAddressGetService getService,
		int stateId,
		CancellationToken cancellationToken) => await getService.GetByState(stateId, cancellationToken);

	/// <summary>
	/// Get addresses by cityId
	/// </summary>
	/// <param name="getService">Address get service</param>
	/// <param name="cityId">Address cityId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded addresses</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("getcity/{cityId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByCityId(
		[FromServices] IAddressGetService getService,
		int cityId,
		CancellationToken cancellationToken) => await getService.GetByCity(cityId, cancellationToken);

	/// <summary>
	/// Get all addresses
	/// </summary>
	/// <param name="getService">Address get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded addresses</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IAddressGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active addresses
	/// </summary>
	/// <param name="getService">Address get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active addresses</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IAddressGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create address
	/// </summary>
	/// <param name="createService">Address create service</param>
	/// <param name="addressCreateAndUpdateDto">Address create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created address</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IAddressCreateService createService,
		AddressCreateAndUpdateRequestDto addressCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(addressCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit address
	/// </summary>
	/// <param name="updateService">Address update service</param>
	/// <param name="addressCreateAndUpdateDto">Address create and update dto</param>
	/// <param name="id">Address id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IAddressUpdateService updateService,
		AddressCreateAndUpdateRequestDto addressCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, addressCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete address
	/// </summary>
	/// <param name="deleteService">Address edit service</param>
	/// <param name="id">Address id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IAddressDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
