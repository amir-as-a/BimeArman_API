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
/// BlogCategory controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/blogcategory")]
[ApiExplorerSettings(GroupName = "Cms - BlogCategories")]
public class BlogCategoriesController : BaseController
{
	/// <summary>
	/// Get blogCategory by id
	/// </summary>
	/// <param name="getService">BlogCategory get service</param>
	/// <param name="id">BlogCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded blogCategories</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> GetById(
		[FromServices] IBlogCategoryGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all blogCategories
	/// </summary>
	/// <param name="getService">BlogCategory get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded blogCategories</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> List(
		[FromServices] IBlogCategoryGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, cancellationToken);

	/// <summary>
	/// Get active blogCategories
	/// </summary>
	/// <param name="getService">BlogCategory get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active blogCategories</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IBlogCategoryGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, cancellationToken);

	/// <summary>
	/// Create blogCategory
	/// </summary>
	/// <param name="createService">BlogCategory create service</param>
	/// <param name="blogCategoryCreateAndUpdateDto">BlogCategory create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created blogCategory</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IBlogCategoryCreateService createService,
		BlogCategoryCreateAndUpdateRequestDto blogCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(blogCategoryCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit blogCategory
	/// </summary>
	/// <param name="updateService">BlogCategory update service</param>
	/// <param name="blogCategoryCreateAndUpdateDto">BlogCategory create and update dto</param>
	/// <param name="id">BlogCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IBlogCategoryUpdateService updateService,
		BlogCategoryCreateAndUpdateRequestDto blogCategoryCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, blogCategoryCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete blogCategory
	/// </summary>
	/// <param name="deleteService">BlogCategory edit service</param>
	/// <param name="id">BlogCategory id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IBlogCategoryDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
