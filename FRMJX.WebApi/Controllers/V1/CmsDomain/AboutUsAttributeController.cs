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
/// AboutUsAttribute controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/aboutUsAttribute")]
[ApiExplorerSettings(GroupName = "Cms - AboutUsAttributes")]
public class AboutUsAttributesController : BaseController
{
	/// <summary>
	/// Get aboutUsAttribute by id
	/// </summary>
	/// <param name="getService">AboutUsAttribute get service</param>
	/// <param name="id">AboutUsAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded aboutUsAttribute</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IAboutUsAttributeGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all aboutUsAttributes
	/// </summary>
	/// <param name="getService">AboutUsAttribute get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded aboutUsAttributes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IAboutUsAttributeGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active aboutUsAttributes
	/// </summary>
	/// <param name="getService">AboutUsAttribute get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active aboutUsAttributes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IAboutUsAttributeGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create aboutUsAttribute
	/// </summary>
	/// <param name="createService">AboutUsAttribute create service</param>
	/// <param name="aboutUsAttributeCreateAndUpdateDto">AboutUsAttribute create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created aboutUsAttribute</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IAboutUsAttributeCreateService createService,
		AboutUsAttributeCreateAndUpdateRequestDto aboutUsAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(aboutUsAttributeCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit aboutUsAttribute
	/// </summary>
	/// <param name="updateService">AboutUsAttribute update service</param>
	/// <param name="aboutUsAttributeCreateAndUpdateDto">AboutUsAttribute create and update dto</param>
	/// <param name="id">AboutUsAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IAboutUsAttributeUpdateService updateService,
		AboutUsAttributeCreateAndUpdateRequestDto aboutUsAttributeCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, aboutUsAttributeCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete aboutUsAttribute
	/// </summary>
	/// <param name="deleteService">AboutUsAttribute edit service</param>
	/// <param name="id">AboutUsAttribute id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IAboutUsAttributeDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
