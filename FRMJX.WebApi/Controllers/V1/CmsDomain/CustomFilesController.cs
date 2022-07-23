namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// CustomFile controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/customfile")]
[ApiExplorerSettings(GroupName = "Cms - CustomFiles")]
public class CustomFilesController : BaseController
{
	/// <summary>
	/// Get image by id
	/// </summary>
	/// <param name="getService">CustomFile get service</param>
	/// <param name="id">Custom File id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded customFiles</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("image/{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetImageById(
		[FromServices] ICustomFileGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, CustomFileType.Image, cancellationToken);

	/// <summary>
	/// Get video by id
	/// </summary>
	/// <param name="getService">CustomFile get service</param>
	/// <param name="id">Custom File id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded customFiles</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("video/{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetVideoById(
		[FromServices] ICustomFileGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, CustomFileType.Video, cancellationToken);

	/// <summary>
	/// Get file by id
	/// </summary>
	/// <param name="getService">CustomFile get service</param>
	/// <param name="id">Custom File id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded customFiles</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("file/{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetFileById(
		[FromServices] ICustomFileGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, CustomFileType.File, cancellationToken);

	/// <summary>
	/// Create image
	/// </summary>
	/// <param name="createService">CustomFile create service</param>
	/// <param name="customFileCreateAndUpdateRequestDto">form file</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created customFile</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost("image")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> CreateImage(
		[FromServices] ICustomFileCreateService createService,
		[FromForm] CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto,
		CancellationToken cancellationToken) => await createService.Create(customFileCreateAndUpdateRequestDto, CustomFileType.Image, cancellationToken);

	/// <summary>
	/// Create video
	/// </summary>
	/// <param name="createService">CustomFile create service</param>
	/// <param name="customFileCreateAndUpdateRequestDto">form file</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created customFile</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost("video")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> CreateVideo(
		[FromServices] ICustomFileCreateService createService,
		[FromForm] CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto,
		CancellationToken cancellationToken) => await createService.Create(customFileCreateAndUpdateRequestDto, CustomFileType.Video, cancellationToken);

	/// <summary>
	/// Create file
	/// </summary>
	/// <param name="createService">CustomFile create service</param>
	/// <param name="customFileCreateAndUpdateRequestDto">form file</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created customFile</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost("file")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> CreateFile(
		[FromServices] ICustomFileCreateService createService,
		[FromForm] CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto,
		CancellationToken cancellationToken) => await createService.Create(customFileCreateAndUpdateRequestDto, CustomFileType.File, cancellationToken);

	/// <summary>
	/// Edit image
	/// </summary>
	/// <param name="updateService">CustomFile update service</param>
	/// <param name="customFileCreateAndUpdateRequestDto">form file</param>
	/// <param name="id">CustomFile id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("image/{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> UpdateImage(
		[FromServices] ICustomFileUpdateService updateService,
		[FromForm] CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, customFileCreateAndUpdateRequestDto, CustomFileType.Image, cancellationToken);

	/// <summary>
	/// Edit video
	/// </summary>
	/// <param name="updateService">CustomFile update service</param>
	/// <param name="customFileCreateAndUpdateRequestDto">form file</param>
	/// <param name="id">CustomFile id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("video/{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> UpdateVideo(
		[FromServices] ICustomFileUpdateService updateService,
		[FromForm] CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, customFileCreateAndUpdateRequestDto, CustomFileType.Video, cancellationToken);

	/// <summary>
	/// Edit file
	/// </summary>
	/// <param name="updateService">CustomFile update service</param>
	/// <param name="customFileCreateAndUpdateRequestDto">form file</param>
	/// <param name="id">CustomFile id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("file/{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> UpdateFile(
		[FromServices] ICustomFileUpdateService updateService,
		[FromForm] CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, customFileCreateAndUpdateRequestDto, CustomFileType.File, cancellationToken);

	/// <summary>
	/// Delete customFile
	/// </summary>
	/// <param name="deleteService">CustomFile edit service</param>
	/// <param name="id">CustomFile id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] ICustomFileDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
