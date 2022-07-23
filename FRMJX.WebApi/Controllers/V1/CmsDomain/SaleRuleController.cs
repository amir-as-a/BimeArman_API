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
/// SaleRule controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/saleRule")]
[ApiExplorerSettings(GroupName = "Cms - SaleRules")]
public class SaleRulesController : BaseController
{
	/// <summary>
	/// Get saleRule by id
	/// </summary>
	/// <param name="getService">SaleRule get service</param>
	/// <param name="id">SaleRule id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded saleRule</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] ISaleRuleGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all saleRules
	/// </summary>
	/// <param name="getService">SaleRule get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded saleRules</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] ISaleRuleGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active saleRules
	/// </summary>
	/// <param name="getService">SaleRule get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active saleRules</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] ISaleRuleGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create saleRule
	/// </summary>
	/// <param name="createService">SaleRule create service</param>
	/// <param name="saleRuleCreateAndUpdateDto">SaleRule create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created saleRule</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] ISaleRuleCreateService createService,
		SaleRuleCreateAndUpdateRequestDto saleRuleCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(saleRuleCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit saleRule
	/// </summary>
	/// <param name="updateService">SaleRule update service</param>
	/// <param name="saleRuleCreateAndUpdateDto">SaleRule create and update dto</param>
	/// <param name="id">SaleRule id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] ISaleRuleUpdateService updateService,
		SaleRuleCreateAndUpdateRequestDto saleRuleCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, saleRuleCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete saleRule
	/// </summary>
	/// <param name="deleteService">SaleRule edit service</param>
	/// <param name="id">SaleRule id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] ISaleRuleDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
