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
/// PersonnelPanel controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/personnelPanel")]
[ApiExplorerSettings(GroupName = "Cms - PersonnelPanel")]
public class PersonnelPanelController : BaseController
{
	/// <summary>
	/// Get personnelPanel by id
	/// </summary>
	/// <param name="getService">PersonnelPanel get service</param>
	/// <param name="id">PersonnelPanel id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded personnelPanel</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IPersonnelPanelGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all personnelPanels
	/// </summary>
	/// <param name="getService">PersonnelPanel get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="categoryId">category Id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded personnelPanels</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IPersonnelPanelGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		[FromQuery] int? categoryId,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, categoryId, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active personnelPanels
	/// </summary>
	/// <param name="getService">PersonnelPanel get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active personnelPanels</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IPersonnelPanelGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create personnelPanel
	/// </summary>
	/// <param name="createService">PersonnelPanel create service</param>
	/// <param name="personnelPanelCreateAndUpdateDto">PersonnelPanel create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created personnelPanel</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IPersonnelPanelCreateService createService,
		PersonnelPanelCreateAndUpdateRequestDto personnelPanelCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(personnelPanelCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit personnelPanel
	/// </summary>
	/// <param name="updateService">PersonnelPanel update service</param>
	/// <param name="personnelPanelCreateAndUpdateDto">PersonnelPanel create and update dto</param>
	/// <param name="id">PersonnelPanel id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IPersonnelPanelUpdateService updateService,
		PersonnelPanelCreateAndUpdateRequestDto personnelPanelCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, personnelPanelCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete personnelPanel
	/// </summary>
	/// <param name="deleteService">PersonnelPanel edit service</param>
	/// <param name="id">PersonnelPanel id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IPersonnelPanelDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
