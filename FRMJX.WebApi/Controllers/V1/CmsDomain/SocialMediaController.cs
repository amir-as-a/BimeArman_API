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
/// SocialMedia controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/socialMedia")]
[ApiExplorerSettings(GroupName = "Cms - SocialMedia")]
public class SocialMediaController : BaseController
{
	/// <summary>
	/// Get socialMedia by id
	/// </summary>
	/// <param name="getService">SocialMedia get service</param>
	/// <param name="id">SocialMedia id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded socialMedia</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] ISocialMediaGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all socialMedias
	/// </summary>
	/// <param name="getService">SocialMedia get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded socialMedias</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] ISocialMediaGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active socialMedias
	/// </summary>
	/// <param name="getService">SocialMedia get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active socialMedias</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] ISocialMediaGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create socialMedia
	/// </summary>
	/// <param name="createService">SocialMedia create service</param>
	/// <param name="socialMediaCreateAndUpdateDto">SocialMedia create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created socialMedia</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] ISocialMediaCreateService createService,
		SocialMediaCreateAndUpdateRequestDto socialMediaCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(socialMediaCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit socialMedia
	/// </summary>
	/// <param name="updateService">SocialMedia update service</param>
	/// <param name="socialMediaCreateAndUpdateDto">SocialMedia create and update dto</param>
	/// <param name="id">SocialMedia id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] ISocialMediaUpdateService updateService,
		SocialMediaCreateAndUpdateRequestDto socialMediaCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, socialMediaCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete socialMedia
	/// </summary>
	/// <param name="deleteService">SocialMedia edit service</param>
	/// <param name="id">SocialMedia id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] ISocialMediaDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
