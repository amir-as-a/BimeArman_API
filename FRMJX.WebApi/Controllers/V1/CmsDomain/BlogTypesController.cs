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
/// BlogType controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/blogtype")]
[ApiExplorerSettings(GroupName = "Cms - BlogTypes")]
public class BlogTypesController : BaseController
{
	/// <summary>
	/// Get blogTypes by id
	/// </summary>
	/// <param name="getService">BlogType get service</param>
	/// <param name="id">BlogType id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded blogType</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> GetById(
		[FromServices] IBlogTypeGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all blogTypes
	/// </summary>
	/// <param name="getService">BlogType get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded blogTypes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> List(
		[FromServices] IBlogTypeGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, cancellationToken);

	/// <summary>
	/// Get active blogTypes
	/// </summary>
	/// <param name="getService">BlogType get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active blogTypes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IBlogTypeGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, cancellationToken);

	/// <summary>
	/// Create blogType
	/// </summary>
	/// <param name="createService">BlogType create service</param>
	/// <param name="blogTypeCreateAndUpdateDto">BlogType create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created blogType</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IBlogTypeCreateService createService,
		BlogTypeCreateAndUpdateRequestDto blogTypeCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(blogTypeCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit blogType
	/// </summary>
	/// <param name="updateService">BlogType update service</param>
	/// <param name="blogTypeCreateAndUpdateDto">BlogType create and update dto</param>
	/// <param name="id">BlogType id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IBlogTypeUpdateService updateService,
		BlogTypeCreateAndUpdateRequestDto blogTypeCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, blogTypeCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete blogType
	/// </summary>
	/// <param name="deleteService">BlogType edit service</param>
	/// <param name="id">BlogType id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IBlogTypeDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
