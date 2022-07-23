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
/// Suggustion controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/suggustion")]
[ApiExplorerSettings(GroupName = "Cms - Suggustions")]
public class SuggustionsController : BaseController
{
	/// <summary>
	/// Get suggustion by id
	/// </summary>
	/// <param name="getService">Suggustion get service</param>
	/// <param name="id">Suggustion id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded suggustion</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] ISuggustionGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all suggustions
	/// </summary>
	/// <param name="getService">Suggustion get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded suggustions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] ISuggustionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active suggustions
	/// </summary>
	/// <param name="getService">Suggustion get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active suggustions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] ISuggustionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create suggustion
	/// </summary>
	/// <param name="createService">Suggustion create service</param>
	/// <param name="suggustionCreateAndUpdateDto">Suggustion create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created suggustion</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Create(
		[FromServices] ISuggustionCreateService createService,
		SuggustionCreateAndUpdateRequestDto suggustionCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(suggustionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit suggustion
	/// </summary>
	/// <param name="updateService">Suggustion update service</param>
	/// <param name="suggustionCreateAndUpdateDto">Suggustion create and update dto</param>
	/// <param name="id">Suggustion id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> Update(
		[FromServices] ISuggustionUpdateService updateService,
		SuggustionCreateAndUpdateRequestDto suggustionCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, suggustionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete suggustion
	/// </summary>
	/// <param name="deleteService">Suggustion edit service</param>
	/// <param name="id">Suggustion id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> Delete(
		[FromServices] ISuggustionDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
