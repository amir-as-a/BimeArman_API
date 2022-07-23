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
/// RepresentativePanelCategory controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/representativePanelCategory")]
[ApiExplorerSettings(GroupName = "Cms - RepresentativePanelCategory")]
public class RepresentativePanelCategoryController : BaseController
{
	/// <summary>
	/// Get representativePanelCategory by id
	/// </summary>
	/// <param name="getService">RepresentativePanelCategory get service</param>
	/// <param name="id">RepresentativePanelCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representativePanelCategory</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IRepresentativePanelCategoryGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all representativePanelCategorys
	/// </summary>
	/// <param name="getService">RepresentativePanelCategory get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representativePanelCategorys</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IRepresentativePanelCategoryGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active representativePanelCategorys
	/// </summary>
	/// <param name="getService">RepresentativePanelCategory get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active representativePanelCategorys</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IRepresentativePanelCategoryGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create representativePanelCategory
	/// </summary>
	/// <param name="createService">RepresentativePanelCategory create service</param>
	/// <param name="representativePanelCategoryCreateAndUpdateDto">RepresentativePanelCategory create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created representativePanelCategory</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IRepresentativePanelCategoryCreateService createService,
		RepresentativePanelCategoryCreateAndUpdateRequestDto representativePanelCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(representativePanelCategoryCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit representativePanelCategory
	/// </summary>
	/// <param name="updateService">RepresentativePanelCategory update service</param>
	/// <param name="representativePanelCategoryCreateAndUpdateDto">RepresentativePanelCategory create and update dto</param>
	/// <param name="id">RepresentativePanelCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IRepresentativePanelCategoryUpdateService updateService,
		RepresentativePanelCategoryCreateAndUpdateRequestDto representativePanelCategoryCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, representativePanelCategoryCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete representativePanelCategory
	/// </summary>
	/// <param name="deleteService">RepresentativePanelCategory edit service</param>
	/// <param name="id">RepresentativePanelCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IRepresentativePanelCategoryDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
