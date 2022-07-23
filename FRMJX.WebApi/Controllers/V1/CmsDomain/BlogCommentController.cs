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
/// BlogComment controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/blogComment")]
[ApiExplorerSettings(GroupName = "Cms - BlogComment")]
public class BlogCommentController : BaseController
{
	/// <summary>
	/// Get blogComments by id
	/// </summary>
	/// <param name="getService">BlogComment get service</param>
	/// <param name="id">BlogComment id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded blogComments</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IBlogCommentGetService getService,
		[FromCommaDelimited] int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all blogComments
	/// </summary>
	/// <param name="getService">BlogComment get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded blogComments</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] IBlogCommentGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active blogComments
	/// </summary>
	/// <param name="getService">BlogComment get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active blogComments</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IBlogCommentGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get blogComments By BlogId
	/// </summary>
	/// <param name="getService">BlogComment get service</param>
	/// <param name="blogId">cblog id</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active blogComments</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/BlogId")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IBlogCommentGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		[FromQuery] int blogId,
		CancellationToken cancellationToken) => await getService.GetByBlogId(blogId, cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create blogComment
	/// </summary>
	/// <param name="createService">BlogComment create service</param>
	/// <param name="blogCommentCreateAndUpdateDto">BlogComment create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created blogComment</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IBlogCommentCreateService createService,
		BlogCommentCreateAndUpdateRequestDto blogCommentCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(blogCommentCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit blogComment
	/// </summary>
	/// <param name="updateService">BlogComment update service</param>
	/// <param name="blogCommentCreateAndUpdateDto">BlogComment create and update dto</param>
	/// <param name="id">BlogComment id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IBlogCommentUpdateService updateService,
		BlogCommentCreateAndUpdateRequestDto blogCommentCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, blogCommentCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit blogComment
	/// </summary>
	/// <param name="updateService">BlogComment update service</param>
	/// <param name="id">BlogComment id</param>
	/// <param name="isApproval">approval</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("Approval/{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> ApprovalComment(
		[FromServices] IBlogCommentUpdateService updateService,
		int id,
		bool isApproval,
		CancellationToken cancellationToken) => await updateService.ApprovalComment(id, isApproval, cancellationToken);

	/// <summary>
	/// Delete blogComment
	/// </summary>
	/// <param name="deleteService">BlogComment edit service</param>
	/// <param name="id">BlogComment id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IBlogCommentDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
