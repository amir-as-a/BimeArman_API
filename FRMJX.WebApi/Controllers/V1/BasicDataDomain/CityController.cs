namespace FRMJX.WebApi.Controllers.V1.BasicDataDomain;

using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Core.BaseDataDomain.Services;
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
/// City controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/basicdata/city")]
[ApiExplorerSettings(GroupName = "Basic Data - City")]
public class CityController : BaseController
{
	/// <summary>
	/// Get city by id
	/// </summary>
	/// <param name="getService">City get service</param>
	/// <param name="id">City id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded city</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] ICityGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Create city
	/// </summary>
	/// <param name="createService">City create service</param>
	/// <param name="cityCreateAndUpdateDto">City create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created city</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.BaseDataManage)]
	public async Task<IActionResult> Create(
		[FromServices] ICityCreateService createService,
		CityCreateAndUpdateRequestDto cityCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(cityCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit city
	/// </summary>
	/// <param name="updateService">City update service</param>
	/// <param name="cityCreateAndUpdateDto">City create and update dto</param>
	/// <param name="id">City id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.BaseDataManage)]
	public async Task<IActionResult> Update(
		[FromServices] ICityUpdateService updateService,
		CityCreateAndUpdateRequestDto cityCreateAndUpdateDto,
		long id,
		CancellationToken cancellationToken) => await updateService.Update(id, cityCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete city
	/// </summary>
	/// <param name="deleteService">City edit service</param>
	/// <param name="id">City id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.BaseDataManage)]
	public async Task<IActionResult> Delete(
		[FromServices] ICityDeleteService deleteService,
		long id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);

	/// <summary>
	/// Get all citys
	/// </summary>
	/// <param name="getService">City get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded citys</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.BaseDataManage)]
	public async Task<IActionResult> List(
		[FromServices] ICityGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetAll(cancellationToken);

	/// <summary>
	/// Get active citys
	/// </summary>
	/// <param name="getService">City get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active citys</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] ICityGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetActives(cancellationToken);
}
