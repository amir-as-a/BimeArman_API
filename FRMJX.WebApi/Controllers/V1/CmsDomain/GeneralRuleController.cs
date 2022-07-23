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
/// GeneralRule controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/generalRule")]
[ApiExplorerSettings(GroupName = "Cms - GeneralRule")]
public class GeneralRuleController : BaseController
{
	/// <summary>
	/// Get generalRule by id
	/// </summary>
	/// <param name="getService">GeneralRule get service</param>
	/// <param name="id">GeneralRule id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded generalRule</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IGeneralRuleGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all generalRules
	/// </summary>
	/// <param name="getService">GeneralRule get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded generalRules</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IGeneralRuleGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active generalRules
	/// </summary>
	/// <param name="getService">GeneralRule get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active generalRules</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IGeneralRuleGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create generalRule
	/// </summary>
	/// <param name="createService">GeneralRule create service</param>
	/// <param name="generalRuleCreateAndUpdateDto">GeneralRule create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created generalRule</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IGeneralRuleCreateService createService,
		GeneralRuleCreateAndUpdateRequestDto generalRuleCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(generalRuleCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit generalRule
	/// </summary>
	/// <param name="updateService">GeneralRule update service</param>
	/// <param name="generalRuleCreateAndUpdateDto">GeneralRule create and update dto</param>
	/// <param name="id">GeneralRule id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IGeneralRuleUpdateService updateService,
		GeneralRuleCreateAndUpdateRequestDto generalRuleCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, generalRuleCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete generalRule
	/// </summary>
	/// <param name="deleteService">GeneralRule edit service</param>
	/// <param name="id">GeneralRule id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IGeneralRuleDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
