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
/// Insurance controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/insurance")]
[ApiExplorerSettings(GroupName = "Cms - Insurances")]
public class InsurancesController : BaseController
{
	/// <summary>
	/// Get insurances by id
	/// </summary>
	/// <param name="getService">Insurance get service</param>
	/// <param name="id">Insurance id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded insurances</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IInsuranceGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all insurances
	/// </summary>
	/// <param name="getService">Insurance get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded insurances</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IInsuranceGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active insurances
	/// </summary>
	/// <param name="getService">Insurance get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active insurances</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IInsuranceGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create insurance
	/// </summary>
	/// <param name="createService">Insurance create service</param>
	/// <param name="insuranceCreateAndUpdateDto">Insurance create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created insurance</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IInsuranceCreateService createService,
		InsuranceCreateAndUpdateRequestDto insuranceCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(insuranceCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit insurance
	/// </summary>
	/// <param name="updateService">Insurance update service</param>
	/// <param name="insuranceCreateAndUpdateDto">Insurance create and update dto</param>
	/// <param name="id">Insurance id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IInsuranceUpdateService updateService,
		InsuranceCreateAndUpdateRequestDto insuranceCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, insuranceCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete insurance
	/// </summary>
	/// <param name="deleteService">Insurance edit service</param>
	/// <param name="id">Insurance id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IInsuranceDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
