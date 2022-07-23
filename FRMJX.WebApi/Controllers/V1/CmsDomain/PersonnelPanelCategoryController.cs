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
/// PersonnelPanelCategory controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/personnelPanelCategory")]
[ApiExplorerSettings(GroupName = "Cms - PersonnelPanelCategory")]
public class PersonnelPanelCategoryController : BaseController
{
	/// <summary>
	/// Get personnelPanelCategory by id
	/// </summary>
	/// <param name="getService">PersonnelPanelCategory get service</param>
	/// <param name="id">PersonnelPanelCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded personnelPanelCategory</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IPersonnelPanelCategoryGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all personnelPanelCategorys
	/// </summary>
	/// <param name="getService">PersonnelPanelCategory get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded personnelPanelCategorys</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IPersonnelPanelCategoryGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active personnelPanelCategorys
	/// </summary>
	/// <param name="getService">PersonnelPanelCategory get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active personnelPanelCategorys</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IPersonnelPanelCategoryGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create personnelPanelCategory
	/// </summary>
	/// <param name="createService">PersonnelPanelCategory create service</param>
	/// <param name="personnelPanelCategoryCreateAndUpdateDto">PersonnelPanelCategory create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created personnelPanelCategory</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IPersonnelPanelCategoryCreateService createService,
		PersonnelPanelCategoryCreateAndUpdateRequestDto personnelPanelCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(personnelPanelCategoryCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit personnelPanelCategory
	/// </summary>
	/// <param name="updateService">PersonnelPanelCategory update service</param>
	/// <param name="personnelPanelCategoryCreateAndUpdateDto">PersonnelPanelCategory create and update dto</param>
	/// <param name="id">PersonnelPanelCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IPersonnelPanelCategoryUpdateService updateService,
		PersonnelPanelCategoryCreateAndUpdateRequestDto personnelPanelCategoryCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, personnelPanelCategoryCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete personnelPanelCategory
	/// </summary>
	/// <param name="deleteService">PersonnelPanelCategory edit service</param>
	/// <param name="id">PersonnelPanelCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IPersonnelPanelCategoryDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
