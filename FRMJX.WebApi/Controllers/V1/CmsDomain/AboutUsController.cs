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
/// AboutUs controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/aboutUs")]
[ApiExplorerSettings(GroupName = "Cms - AboutUs")]
public class AboutUsController : BaseController
{
	/// <summary>
	/// Get aboutUs by id
	/// </summary>
	/// <param name="getService">AboutUs get service</param>
	/// <param name="id">AboutUs id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded aboutUs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IAboutUsGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all aboutUss
	/// </summary>
	/// <param name="getService">AboutUs get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded aboutUss</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IAboutUsGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active aboutUss
	/// </summary>
	/// <param name="getService">AboutUs get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active aboutUss</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IAboutUsGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create aboutUs
	/// </summary>
	/// <param name="createService">AboutUs create service</param>
	/// <param name="aboutUsCreateAndUpdateDto">AboutUs create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created aboutUs</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IAboutUsCreateService createService,
		AboutUsCreateAndUpdateRequestDto aboutUsCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(aboutUsCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit aboutUs
	/// </summary>
	/// <param name="updateService">AboutUs update service</param>
	/// <param name="aboutUsCreateAndUpdateDto">AboutUs create and update dto</param>
	/// <param name="id">AboutUs id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IAboutUsUpdateService updateService,
		AboutUsCreateAndUpdateRequestDto aboutUsCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, aboutUsCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete aboutUs
	/// </summary>
	/// <param name="deleteService">AboutUs edit service</param>
	/// <param name="id">AboutUs id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IAboutUsDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
