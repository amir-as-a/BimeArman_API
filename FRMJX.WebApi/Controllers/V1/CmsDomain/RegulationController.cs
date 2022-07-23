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
/// Regulation controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/regulation")]
[ApiExplorerSettings(GroupName = "Cms - Regulation")]
public class RegulationController : BaseController
{
	/// <summary>
	/// Get regulation by id
	/// </summary>
	/// <param name="getService">Regulation get service</param>
	/// <param name="id">Regulation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded regulation</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IRegulationGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all regulations
	/// </summary>
	/// <param name="getService">Regulation get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded regulations</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IRegulationGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active regulations
	/// </summary>
	/// <param name="getService">Regulation get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active regulations</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IRegulationGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create regulation
	/// </summary>
	/// <param name="createService">Regulation create service</param>
	/// <param name="regulationCreateAndUpdateDto">Regulation create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created regulation</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IRegulationCreateService createService,
		RegulationCreateAndUpdateRequestDto regulationCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(regulationCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit regulation
	/// </summary>
	/// <param name="updateService">Regulation update service</param>
	/// <param name="regulationCreateAndUpdateDto">Regulation create and update dto</param>
	/// <param name="id">Regulation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IRegulationUpdateService updateService,
		RegulationCreateAndUpdateRequestDto regulationCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, regulationCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete regulation
	/// </summary>
	/// <param name="deleteService">Regulation edit service</param>
	/// <param name="id">Regulation id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IRegulationDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
