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
/// BlogPost controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/blogpost")]
[ApiExplorerSettings(GroupName = "Cms - BlogPosts")]
public class BlogPostsController : BaseController
{
	/// <summary>
	/// Get blogPosts by id
	/// </summary>
	/// <param name="getService">BlogPost get service</param>
	/// <param name="id">BlogPost id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded blogPost</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> GetById(
		[FromServices] IBlogPostGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all blogPosts
	/// </summary>
	/// <param name="getService">BlogPost get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="isActive">Active or not Active</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded blogPosts</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> List(
		[FromServices] IBlogPostGetService getService,
		[FromHeader] int cultureLcid,
		bool isActive,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, isActive, cancellationToken);

	/// <summary>
	/// Get active blogPosts
	/// </summary>
	/// <param name="getService">BlogPost get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active blogPosts</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IBlogPostGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, cancellationToken);

	/// <summary>
	/// Get Last blogPosts
	/// </summary>
	/// <param name="getService">BlogPost get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded latest blogPosts</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/lastBlogs")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> GetLastBlogs(
		[FromServices] IBlogPostGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetlastBlogs(cultureLcid, cancellationToken);

	/// <summary>
	/// Create blogPost
	/// </summary>
	/// <param name="createService">BlogPost create service</param>
	/// <param name="blogPostCreateAndUpdateDto">BlogPost create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created blogPost</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IBlogPostCreateService createService,
		BlogPostCreateAndUpdateRequestDto blogPostCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(blogPostCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit blogPost
	/// </summary>
	/// <param name="updateService">BlogPost update service</param>
	/// <param name="blogPostCreateAndUpdateDto">BlogPost create and update dto</param>
	/// <param name="id">BlogPost id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
	[FromServices] IBlogPostUpdateService updateService,
	BlogPostCreateAndUpdateRequestDto blogPostCreateAndUpdateDto,
	int id,
	CancellationToken cancellationToken) => await updateService.Update(id, blogPostCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete blogPost
	/// </summary>
	/// <param name="deleteService">BlogPost edit service</param>
	/// <param name="id">BlogPost id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IBlogPostDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
