namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Vision controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/vision")]
[ApiExplorerSettings(GroupName = "Cms - Visions")]
public class VisionsController : BaseController
{
	/// <summary>
	/// Get vision by id
	/// </summary>
	/// <param name="getService">Vision get service</param>
	/// <param name="id">Vision id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded vision</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IVisionGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all visions
	/// </summary>
	/// <param name="getService">Vision get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded visions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IVisionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active visions
	/// </summary>
	/// <param name="getService">Vision get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active visions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IVisionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create vision
	/// </summary>
	/// <param name="createService">Vision create service</param>
	/// <param name="visionCreateAndUpdateDto">Vision create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created vision</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IVisionCreateService createService,
		VisionCreateAndUpdateRequestDto visionCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(visionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit vision
	/// </summary>
	/// <param name="updateService">Vision update service</param>
	/// <param name="visionCreateAndUpdateDto">Vision create and update dto</param>
	/// <param name="id">Vision id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IVisionUpdateService updateService,
		VisionCreateAndUpdateRequestDto visionCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, visionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete vision
	/// </summary>
	/// <param name="deleteService">Vision edit service</param>
	/// <param name="id">Vision id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IVisionDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
