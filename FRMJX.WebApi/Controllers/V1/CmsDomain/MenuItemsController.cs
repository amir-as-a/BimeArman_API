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
/// MenuItem controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/menuitem")]
[ApiExplorerSettings(GroupName = "Cms - MenuItems")]
public class MenuItemsController : BaseController
{
	/// <summary>
	/// Get menuItem by id
	/// </summary>
	/// <param name="getService">MenuItem get service</param>
	/// <param name="id">MenuItem id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded menuItem</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IMenuItemGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all menuItems
	/// </summary>
	/// <param name="getService">MenuItem get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="parentId">Parent Id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded menuItems</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/{parentId}")]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] IMenuItemGetService getService,
		[FromHeader] int cultureLcid,
		int? parentId,
		CancellationToken cancellationToken) => await getService.GetByParentId(cultureLcid, parentId, cancellationToken);

	/// <summary>
	/// Get active menuItems
	/// </summary>
	/// <param name="getService">MenuItem get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="parentId">parent Id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active menuItems</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/active/{parentId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IMenuItemGetService getService,
		[FromHeader] int cultureLcid,
		int? parentId,
		CancellationToken cancellationToken) => await getService.GetActivesByParentId(cultureLcid, parentId, cancellationToken);

	/// <summary>
	/// Get all menuItems
	/// </summary>
	/// <param name="getService">MenuItem get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded menuItems</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list")]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] IMenuItemGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, cancellationToken);

	/// <summary>
	/// Get active menuItems
	/// </summary>
	/// <param name="getService">MenuItem get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active menuItems</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IMenuItemGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, cancellationToken);

	/// <summary>
	/// Create menuItem
	/// </summary>
	/// <param name="createService">MenuItem create service</param>
	/// <param name="menuItemCreateAndUpdateDto">MenuItem create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created menuItem</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IMenuItemCreateService createService,
		MenuItemCreateAndUpdateRequestDto menuItemCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(menuItemCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit menuItem
	/// </summary>
	/// <param name="updateService">MenuItem update service</param>
	/// <param name="menuItemCreateAndUpdateDto">MenuItem create and update dto</param>
	/// <param name="id">MenuItem id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IMenuItemUpdateService updateService,
		MenuItemCreateAndUpdateRequestDto menuItemCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, menuItemCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete menuItem
	/// </summary>
	/// <param name="deleteService">MenuItem edit service</param>
	/// <param name="id">MenuItem id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IMenuItemDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);

	/// <summary>
	/// Get FirstFooter menuItems
	/// </summary>
	/// <param name="getService">FirstFooter get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded FirstFooter</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/FirstFooterList")]
	[AllowAnonymous]
	public async Task<IActionResult> FirstFooterList(
		[FromServices] IMenuItemGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetFirstFooter(cultureLcid, cancellationToken);

	/// <summary>
	/// Get SecendFooter menuItems
	/// </summary>
	/// <param name="getService">SecendFooter get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded SecendFooter</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/SecendFooterList")]
	[AllowAnonymous]
	public async Task<IActionResult> SecendFooterList(
		[FromServices] IMenuItemGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetSecendFooter(cultureLcid, cancellationToken);

	/// <summary>
	/// Get ThirdFooter menuItems
	/// </summary>
	/// <param name="getService">ThirdFooter get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded ThirdFooter</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/ThirdFooterList")]
	[AllowAnonymous]
	public async Task<IActionResult> ThirdFooterList(
		[FromServices] IMenuItemGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetThirdFooter(cultureLcid, cancellationToken);

	/// <summary>
	/// Get  menuItems
	/// </summary>
	/// <param name="getService">MenuItem get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded MenuItem</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/MenuItemList")]
	[AllowAnonymous]
	public async Task<IActionResult> MenuItemList(
		[FromServices] IMenuItemGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetMenuItem(cultureLcid, cancellationToken);
}
