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
/// Image controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/image")]
[ApiExplorerSettings(GroupName = "Cms - Images")]
public class ImagesController : BaseController
{
	/// <summary>
	/// Get image by id
	/// </summary>
	/// <param name="getService">Image get service</param>
	/// <param name="id">Image id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded image</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IImageGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all images
	/// </summary>
	/// <param name="getService">Image get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded images</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IImageGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active images
	/// </summary>
	/// <param name="getService">Image get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active images</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IImageGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create image
	/// </summary>
	/// <param name="createService">Image create service</param>
	/// <param name="imageCreateAndUpdateDto">Image create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created image</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IImageCreateService createService,
		ImageCreateAndUpdateRequestDto imageCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(imageCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit image
	/// </summary>
	/// <param name="updateService">Image update service</param>
	/// <param name="imageCreateAndUpdateDto">Image create and update dto</param>
	/// <param name="id">Image id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IImageUpdateService updateService,
		ImageCreateAndUpdateRequestDto imageCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, imageCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete image
	/// </summary>
	/// <param name="deleteService">Image edit service</param>
	/// <param name="id">Image id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IImageDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
