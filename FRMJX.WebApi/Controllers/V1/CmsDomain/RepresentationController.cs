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
/// Representation controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/representation")]
[ApiExplorerSettings(GroupName = "Cms - Representationes")]
public class RepresentationesController : BaseController
{
	/// <summary>
	/// Get representationes by id
	/// </summary>
	/// <param name="getService">Representation get service</param>
	/// <param name="id">Representation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representatione</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IRepresentationGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get representationes by stateId
	/// </summary>
	/// <param name="getService">Representation get service</param>
	/// <param name="stateId">Representation stateId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representationes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("getstate/{stateId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByStateId(
		[FromServices] IRepresentationGetService getService,
		int stateId,
		CancellationToken cancellationToken) => await getService.GetByState(stateId, cancellationToken);

	/// <summary>
	/// Get representationes by cityId
	/// </summary>
	/// <param name="getService">Representation get service</param>
	/// <param name="cityId">Representation cityId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representationes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("getcity/{cityId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByCityId(
		[FromServices] IRepresentationGetService getService,
		int cityId,
		CancellationToken cancellationToken) => await getService.GetByCity(cityId, cancellationToken);

	/// <summary>
	/// Get all representationes
	/// </summary>
	/// <param name="getService">Representation get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representationes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IRepresentationGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active representationes
	/// </summary>
	/// <param name="getService">Representation get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active representationes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IRepresentationGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create representation
	/// </summary>
	/// <param name="createService">Representation create service</param>
	/// <param name="representationCreateAndUpdateDto">Representation create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created representation</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IRepresentationCreateService createService,
		RepresentationCreateAndUpdateRequestDto representationCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(representationCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit representation
	/// </summary>
	/// <param name="updateService">Representation update service</param>
	/// <param name="representationCreateAndUpdateDto">Representation create and update dto</param>
	/// <param name="id">Representation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IRepresentationUpdateService updateService,
		RepresentationCreateAndUpdateRequestDto representationCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, representationCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete representation
	/// </summary>
	/// <param name="deleteService">Representation edit service</param>
	/// <param name="id">Representation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IRepresentationDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
