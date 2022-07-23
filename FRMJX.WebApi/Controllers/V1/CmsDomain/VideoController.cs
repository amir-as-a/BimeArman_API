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
/// Video controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/video")]
[ApiExplorerSettings(GroupName = "Cms - Videos")]
public class VideosController : BaseController
{
	/// <summary>
	/// Get video by id
	/// </summary>
	/// <param name="getService">Video get service</param>
	/// <param name="id">Video id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded video</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IVideoGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all videos
	/// </summary>
	/// <param name="getService">Video get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded videos</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IVideoGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active videos
	/// </summary>
	/// <param name="getService">Video get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active videos</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IVideoGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create video
	/// </summary>
	/// <param name="createService">Video create service</param>
	/// <param name="videoCreateAndUpdateDto">Video create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created video</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IVideoCreateService createService,
		VideoCreateAndUpdateRequestDto videoCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(videoCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit video
	/// </summary>
	/// <param name="updateService">Video update service</param>
	/// <param name="videoCreateAndUpdateDto">Video create and update dto</param>
	/// <param name="id">Video id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IVideoUpdateService updateService,
		VideoCreateAndUpdateRequestDto videoCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, videoCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete video
	/// </summary>
	/// <param name="deleteService">Video edit service</param>
	/// <param name="id">Video id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IVideoDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
