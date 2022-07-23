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
/// RepresentativePanel controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/representativePanel")]
[ApiExplorerSettings(GroupName = "Cms - RepresentativePanel")]
public class RepresentativePanelController : BaseController
{
	/// <summary>
	/// Get representativePanel by id
	/// </summary>
	/// <param name="getService">RepresentativePanel get service</param>
	/// <param name="id">RepresentativePanel id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representativePanel</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IRepresentativePanelGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all representativePanels
	/// </summary>
	/// <param name="getService">RepresentativePanel get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="categoryId">category id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representativePanels</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IRepresentativePanelGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		[FromQuery] int? categoryId,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, categoryId, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active representativePanels
	/// </summary>
	/// <param name="getService">RepresentativePanel get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active representativePanels</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IRepresentativePanelGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create representativePanel
	/// </summary>
	/// <param name="createService">RepresentativePanel create service</param>
	/// <param name="representativePanelCreateAndUpdateDto">RepresentativePanel create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created representativePanel</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IRepresentativePanelCreateService createService,
		RepresentativePanelCreateAndUpdateRequestDto representativePanelCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(representativePanelCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit representativePanel
	/// </summary>
	/// <param name="updateService">RepresentativePanel update service</param>
	/// <param name="representativePanelCreateAndUpdateDto">RepresentativePanel create and update dto</param>
	/// <param name="id">RepresentativePanel id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IRepresentativePanelUpdateService updateService,
		RepresentativePanelCreateAndUpdateRequestDto representativePanelCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, representativePanelCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete representativePanel
	/// </summary>
	/// <param name="deleteService">RepresentativePanel edit service</param>
	/// <param name="id">RepresentativePanel id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IRepresentativePanelDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
