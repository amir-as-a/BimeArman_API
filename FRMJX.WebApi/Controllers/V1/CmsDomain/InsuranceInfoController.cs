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
/// InsuranceInfo controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/insuranceInfo")]
[ApiExplorerSettings(GroupName = "Cms - InsuranceInfos")]
public class InsuranceInfosController : BaseController
{
	/// <summary>
	/// Get insuranceInfo by id
	/// </summary>
	/// <param name="getService">InsuranceInfo get service</param>
	/// <param name="id">InsuranceInfo id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded insuranceInfo</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IInsuranceInfoGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get insuranceInfos by insuranceId
	/// </summary>
	/// <param name="getService">InsuranceInfo get service</param>
	/// <param name="insuranceId">InsuranceInfo insuranceId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded insuranceInfos</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("insurance/{insuranceId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByinsuranceId(
		[FromServices] IInsuranceInfoGetService getService,
		int insuranceId,
		CancellationToken cancellationToken) => await getService.GetByInsuranceId(insuranceId, cancellationToken);

	/// <summary>
	/// Get all insuranceInfos
	/// </summary>
	/// <param name="getService">InsuranceInfo get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded insuranceInfos</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IInsuranceInfoGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active insuranceInfos
	/// </summary>
	/// <param name="getService">InsuranceInfo get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active insuranceInfos</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IInsuranceInfoGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create insuranceInfo
	/// </summary>
	/// <param name="createService">InsuranceInfo create service</param>
	/// <param name="insuranceInfoCreateAndUpdateDto">InsuranceInfo create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created insuranceInfo</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IInsuranceInfoCreateService createService,
		InsuranceInfoCreateAndUpdateRequestDto insuranceInfoCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(insuranceInfoCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit insuranceInfo
	/// </summary>
	/// <param name="updateService">InsuranceInfo update service</param>
	/// <param name="insuranceInfoCreateAndUpdateDto">InsuranceInfo create and update dto</param>
	/// <param name="id">InsuranceInfo id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IInsuranceInfoUpdateService updateService,
		InsuranceInfoCreateAndUpdateRequestDto insuranceInfoCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, insuranceInfoCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete insuranceInfo
	/// </summary>
	/// <param name="deleteService">InsuranceInfo edit service</param>
	/// <param name="id">InsuranceInfo id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IInsuranceInfoDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
