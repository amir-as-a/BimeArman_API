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
/// JobPosition controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/jobPosition")]
[ApiExplorerSettings(GroupName = "Cms - JobPositions")]
public class JobPositionsController : BaseController
{
	/// <summary>
	/// Get jobPosition by id
	/// </summary>
	/// <param name="getService">JobPosition get service</param>
	/// <param name="id">JobPosition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded jobPosition</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IJobPositionGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all jobPositions
	/// </summary>
	/// <param name="getService">JobPosition get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded jobPositions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] IJobPositionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active jobPositions
	/// </summary>
	/// <param name="getService">JobPosition get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active jobPositions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IJobPositionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create jobPosition
	/// </summary>
	/// <param name="createService">JobPosition create service</param>
	/// <param name="jobPositionCreateAndUpdateDto">JobPosition create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created jobPosition</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IJobPositionCreateService createService,
		JobPositionCreateAndUpdateRequestDto jobPositionCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(jobPositionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit jobPosition
	/// </summary>
	/// <param name="updateService">JobPosition update service</param>
	/// <param name="jobPositionCreateAndUpdateDto">JobPosition create and update dto</param>
	/// <param name="id">JobPosition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IJobPositionUpdateService updateService,
		JobPositionCreateAndUpdateRequestDto jobPositionCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, jobPositionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete jobPosition
	/// </summary>
	/// <param name="deleteService">JobPosition edit service</param>
	/// <param name="id">JobPosition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IJobPositionDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
