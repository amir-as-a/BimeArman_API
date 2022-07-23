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
/// RevelationAttribute controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/revelationAttribute")]
[ApiExplorerSettings(GroupName = "Cms - RevelationAttributes")]
public class RevelationAttributesController : BaseController
{
	/// <summary>
	/// Get revelationAttributes by id
	/// </summary>
	/// <param name="getService">RevelationAttribute get service</param>
	/// <param name="id">RevelationAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded revelationAttribute</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IRevelationAttributeGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get revelationAttributes by revelationId
	/// </summary>
	/// <param name="getService">RevelationAttribute get service</param>
	/// <param name="id">Revelation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded revelationAttributes</returns>
	/*[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{revelationid}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByRevelationId(
		[FromServices] IRevelationAttributeGetService getService,
		[FromQuery] int id,
		CancellationToken cancellationToken) => await getService.GetByRevelationId(id, cancellationToken);*/

	/// <summary>
	/// Get all revelationAttributes
	/// </summary>
	/// <param name="getService">RevelationAttribute get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded revelationAttributes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IRevelationAttributeGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active revelationAttributes
	/// </summary>
	/// <param name="getService">RevelationAttribute get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active revelationAttributes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IRevelationAttributeGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create revelationAttribute
	/// </summary>
	/// <param name="createService">RevelationAttribute create service</param>
	/// <param name="revelationAttributeCreateAndUpdateDto">RevelationAttribute create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created revelationAttribute</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IRevelationAttributeCreateService createService,
		RevelationAttributeCreateAndUpdateRequestDto revelationAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(revelationAttributeCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit revelationAttribute
	/// </summary>
	/// <param name="updateService">RevelationAttribute update service</param>
	/// <param name="revelationAttributeCreateAndUpdateDto">RevelationAttribute create and update dto</param>
	/// <param name="id">RevelationAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IRevelationAttributeUpdateService updateService,
		RevelationAttributeCreateAndUpdateRequestDto revelationAttributeCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, revelationAttributeCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete revelationAttribute
	/// </summary>
	/// <param name="deleteService">RevelationAttribute edit service</param>
	/// <param name="id">RevelationAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IRevelationAttributeDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
