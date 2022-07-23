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
/// UsefulLink controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/usefulLink")]
[ApiExplorerSettings(GroupName = "Cms - UsefulLink")]
public class UsefulLinkController : BaseController
{
	/// <summary>
	/// Get usefulLink by id
	/// </summary>
	/// <param name="getService">UsefulLink get service</param>
	/// <param name="id">UsefulLink id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded usefulLink</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IUsefulLinkGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all usefulLinks
	/// </summary>
	/// <param name="getService">UsefulLink get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded usefulLinks</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IUsefulLinkGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active usefulLinks
	/// </summary>
	/// <param name="getService">UsefulLink get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active usefulLinks</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IUsefulLinkGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active personnelLink
	/// </summary>
	/// <param name="getService">personnelLink get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active personnelLink</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/personnelLink")]
	[AllowAnonymous]
	public async Task<IActionResult> GetPersonnelLink(
		[FromServices] IUsefulLinkGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetPersonnelLink(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active RepresentationLink
	/// </summary>
	/// <param name="getService">personnelLink get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active RepresentationLink</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/representationLink")]
	[AllowAnonymous]
	public async Task<IActionResult> GetRepresentationLink(
		[FromServices] IUsefulLinkGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetRepresentationLink(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create usefulLink
	/// </summary>
	/// <param name="createService">UsefulLink create service</param>
	/// <param name="usefulLinkCreateAndUpdateDto">UsefulLink create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created usefulLink</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IUsefulLinkCreateService createService,
		UsefulLinkCreateAndUpdateRequestDto usefulLinkCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(usefulLinkCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit usefulLink
	/// </summary>
	/// <param name="updateService">UsefulLink update service</param>
	/// <param name="usefulLinkCreateAndUpdateDto">UsefulLink create and update dto</param>
	/// <param name="id">UsefulLink id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IUsefulLinkUpdateService updateService,
		UsefulLinkCreateAndUpdateRequestDto usefulLinkCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, usefulLinkCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete usefulLink
	/// </summary>
	/// <param name="deleteService">UsefulLink edit service</param>
	/// <param name="id">UsefulLink id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IUsefulLinkDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
