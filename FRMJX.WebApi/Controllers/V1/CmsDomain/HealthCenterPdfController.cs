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
/// HealthCenterPdf controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/healthCenterPdf")]
[ApiExplorerSettings(GroupName = "Cms - HealthCenterPdfs")]
public class HealthCenterPdfsController : BaseController
{
	/// <summary>
	/// Get healthCenterPdfs by id
	/// </summary>
	/// <param name="getService">HealthCenterPdf get service</param>
	/// <param name="id">HealthCenterPdf id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded healthCenterPdfs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IHealthCenterPdfGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get healthCenterPdfs by satateId
	/// </summary>
	/// <param name="getService">HealthCenterPdf get service</param>
	/// <param name="satateId">HealthCenterPdf satateId</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded healthCenterPdfs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/{satateId}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByIds(
		[FromServices] IHealthCenterPdfGetService getService,
		[FromQuery] int satateId,
		CancellationToken cancellationToken) => await getService.GetByState(satateId, cancellationToken);

	/// <summary>
	/// Get all healthCenterPdfs
	/// </summary>
	/// <param name="getService">HealthCenterPdf get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="stateId">state Id</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded healthCenterPdfs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] IHealthCenterPdfGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int? stateId,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid,stateId, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active healthCenterPdfs
	/// </summary>
	/// <param name="getService">HealthCenterPdf get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active healthCenterPdfs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IHealthCenterPdfGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create healthCenterPdf
	/// </summary>
	/// <param name="createService">HealthCenterPdf create service</param>
	/// <param name="healthCenterPdfCreateAndUpdateDto">HealthCenterPdf create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created healthCenterPdf</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IHealthCenterPdfCreateService createService,
		HealthCenterPdfCreateAndUpdateRequestDto healthCenterPdfCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(healthCenterPdfCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit healthCenterPdf
	/// </summary>
	/// <param name="updateService">HealthCenterPdf update service</param>
	/// <param name="healthCenterPdfCreateAndUpdateDto">HealthCenterPdf create and update dto</param>
	/// <param name="id">HealthCenterPdf id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IHealthCenterPdfUpdateService updateService,
		HealthCenterPdfCreateAndUpdateRequestDto healthCenterPdfCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, healthCenterPdfCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete healthCenterPdf
	/// </summary>
	/// <param name="deleteService">HealthCenterPdf edit service</param>
	/// <param name="id">HealthCenterPdf id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IHealthCenterPdfDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
