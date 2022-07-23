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
/// VisionAttribute controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/visionAttribute")]
[ApiExplorerSettings(GroupName = "Cms - VisionAttributes")]
public class VisionAttributesController : BaseController
{
	/// <summary>
	/// Get visionAttribute by id
	/// </summary>
	/// <param name="getService">VisionAttribute get service</param>
	/// <param name="id">VisionAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded visionAttribute</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IVisionAttributeGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all visionAttributes
	/// </summary>
	/// <param name="getService">VisionAttribute get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded visionAttributes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IVisionAttributeGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active visionAttributes
	/// </summary>
	/// <param name="getService">VisionAttribute get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active visionAttributes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IVisionAttributeGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create visionAttribute
	/// </summary>
	/// <param name="createService">VisionAttribute create service</param>
	/// <param name="visionAttributeCreateAndUpdateDto">VisionAttribute create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created visionAttribute</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IVisionAttributeCreateService createService,
		VisionAttributeCreateAndUpdateRequestDto visionAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(visionAttributeCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit visionAttribute
	/// </summary>
	/// <param name="updateService">VisionAttribute update service</param>
	/// <param name="visionAttributeCreateAndUpdateDto">VisionAttribute create and update dto</param>
	/// <param name="id">VisionAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IVisionAttributeUpdateService updateService,
		VisionAttributeCreateAndUpdateRequestDto visionAttributeCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, visionAttributeCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete visionAttribute
	/// </summary>
	/// <param name="deleteService">VisionAttribute edit service</param>
	/// <param name="id">VisionAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IVisionAttributeDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
