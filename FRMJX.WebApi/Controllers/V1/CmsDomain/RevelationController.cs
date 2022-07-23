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
/// Revelation controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/revelation")]
[ApiExplorerSettings(GroupName = "Cms - Revelations")]
public class RevelationsController : BaseController
{
	/// <summary>
	/// Get revelation by id
	/// </summary>
	/// <param name="getService">Revelation get service</param>
	/// <param name="id">Revelation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded revelation</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IRevelationGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all revelations
	/// </summary>
	/// <param name="getService">Revelation get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded revelations</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IRevelationGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active revelations
	/// </summary>
	/// <param name="getService">Revelation get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active revelations</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IRevelationGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create revelation
	/// </summary>
	/// <param name="createService">Revelation create service</param>
	/// <param name="revelationCreateAndUpdateDto">Revelation create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created revelation</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IRevelationCreateService createService,
		RevelationCreateAndUpdateRequestDto revelationCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(revelationCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit revelation
	/// </summary>
	/// <param name="updateService">Revelation update service</param>
	/// <param name="revelationCreateAndUpdateDto">Revelation create and update dto</param>
	/// <param name="id">Revelation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IRevelationUpdateService updateService,
		RevelationCreateAndUpdateRequestDto revelationCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, revelationCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete revelation
	/// </summary>
	/// <param name="deleteService">Revelation edit service</param>
	/// <param name="id">Revelation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IRevelationDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
