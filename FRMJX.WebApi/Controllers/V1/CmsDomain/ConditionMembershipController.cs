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
/// ConditionMembership controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/conditionMembership")]
[ApiExplorerSettings(GroupName = "Cms - ConditionMembership")]
public class ConditionMembershipController : BaseController
{
	/// <summary>
	/// Get conditionMembership by id
	/// </summary>
	/// <param name="getService">ConditionMembership get service</param>
	/// <param name="id">ConditionMembership id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded conditionMembership</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IConditionMembershipGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all conditionMemberships
	/// </summary>
	/// <param name="getService">ConditionMembership get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded conditionMemberships</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IConditionMembershipGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active conditionMemberships
	/// </summary>
	/// <param name="getService">ConditionMembership get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active conditionMemberships</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IConditionMembershipGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create conditionMembership
	/// </summary>
	/// <param name="createService">ConditionMembership create service</param>
	/// <param name="conditionMembershipCreateAndUpdateDto">ConditionMembership create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created conditionMembership</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IConditionMembershipCreateService createService,
		ConditionMembershipCreateAndUpdateRequestDto conditionMembershipCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(conditionMembershipCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit conditionMembership
	/// </summary>
	/// <param name="updateService">ConditionMembership update service</param>
	/// <param name="conditionMembershipCreateAndUpdateDto">ConditionMembership create and update dto</param>
	/// <param name="id">ConditionMembership id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IConditionMembershipUpdateService updateService,
		ConditionMembershipCreateAndUpdateRequestDto conditionMembershipCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, conditionMembershipCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete conditionMembership
	/// </summary>
	/// <param name="deleteService">ConditionMembership edit service</param>
	/// <param name="id">ConditionMembership id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IConditionMembershipDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
