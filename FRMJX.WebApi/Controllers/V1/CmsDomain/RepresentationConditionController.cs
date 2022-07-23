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
/// RepresentationCondition controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/representationCondition")]
[ApiExplorerSettings(GroupName = "Cms - RepresentationConditions")]
public class RepresentationConditionsController : BaseController
{
	/// <summary>
	/// Get representationCondition by id
	/// </summary>
	/// <param name="getService">RepresentationCondition get service</param>
	/// <param name="id">RepresentationCondition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representationCondition</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IRepresentationConditionGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all representationConditions
	/// </summary>
	/// <param name="getService">RepresentationCondition get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded representationConditions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IRepresentationConditionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active representationConditions
	/// </summary>
	/// <param name="getService">RepresentationCondition get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active representationConditions</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IRepresentationConditionGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create representationCondition
	/// </summary>
	/// <param name="createService">RepresentationCondition create service</param>
	/// <param name="representationConditionCreateAndUpdateDto">RepresentationCondition create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created representationCondition</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IRepresentationConditionCreateService createService,
		RepresentationConditionCreateAndUpdateRequestDto representationConditionCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(representationConditionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit representationCondition
	/// </summary>
	/// <param name="updateService">RepresentationCondition update service</param>
	/// <param name="representationConditionCreateAndUpdateDto">RepresentationCondition create and update dto</param>
	/// <param name="id">RepresentationCondition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IRepresentationConditionUpdateService updateService,
		RepresentationConditionCreateAndUpdateRequestDto representationConditionCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, representationConditionCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete representationCondition
	/// </summary>
	/// <param name="deleteService">RepresentationCondition edit service</param>
	/// <param name="id">RepresentationCondition id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IRepresentationConditionDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
