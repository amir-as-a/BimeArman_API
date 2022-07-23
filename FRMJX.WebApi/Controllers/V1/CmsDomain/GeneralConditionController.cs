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
/// GeneralCondition controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/generalCondition")]
[ApiExplorerSettings(GroupName = "Cms - GeneralCondition")]
public class GeneralConditionController : BaseController
{
	/// <summary>
	/// Get generalCondition by id
	/// </summary>
	/// <param name="getService">GeneralCondition get service</param>
	/// <param name="id">GeneralCondition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded generalCondition</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IGeneralConditionGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all generalConditions
	/// </summary>
	/// <param name="getService">GeneralCondition get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded generalConditions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IGeneralConditionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active generalConditions
	/// </summary>
	/// <param name="getService">GeneralCondition get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active generalConditions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IGeneralConditionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create generalCondition
	/// </summary>
	/// <param name="createService">GeneralCondition create service</param>
	/// <param name="generalConditionCreateAndUpdateDto">GeneralCondition create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created generalCondition</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IGeneralConditionCreateService createService,
		GeneralConditionCreateAndUpdateRequestDto generalConditionCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(generalConditionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit generalCondition
	/// </summary>
	/// <param name="updateService">GeneralCondition update service</param>
	/// <param name="generalConditionCreateAndUpdateDto">GeneralCondition create and update dto</param>
	/// <param name="id">GeneralCondition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IGeneralConditionUpdateService updateService,
		GeneralConditionCreateAndUpdateRequestDto generalConditionCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, generalConditionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete generalCondition
	/// </summary>
	/// <param name="deleteService">GeneralCondition edit service</param>
	/// <param name="id">GeneralCondition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IGeneralConditionDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
