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
/// ContactUs controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/contactUs")]
[ApiExplorerSettings(GroupName = "Cms - ContactUs")]
public class ContactUssController : BaseController
{
	/// <summary>
	/// Get contactUs by id
	/// </summary>
	/// <param name="getService">ContactUs get service</param>
	/// <param name="id">ContactUs id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded contactUs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IContactUsGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all contactUss
	/// </summary>
	/// <param name="getService">ContactUs get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded contactUss</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] IContactUsGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active contactUss
	/// </summary>
	/// <param name="getService">ContactUs get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active contactUss</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IContactUsGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create contactUs
	/// </summary>
	/// <param name="createService">ContactUs create service</param>
	/// <param name="contactUsCreateAndUpdateDto">ContactUs create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created contactUs</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Create(
		[FromServices] IContactUsCreateService createService,
		ContactUsCreateAndUpdateRequestDto contactUsCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(contactUsCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit contactUs
	/// </summary>
	/// <param name="updateService">ContactUs update service</param>
	/// <param name="contactUsCreateAndUpdateDto">ContactUs create and update dto</param>
	/// <param name="id">ContactUs id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> Update(
		[FromServices] IContactUsUpdateService updateService,
		ContactUsCreateAndUpdateRequestDto contactUsCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, contactUsCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete contactUs
	/// </summary>
	/// <param name="deleteService">ContactUs edit service</param>
	/// <param name="id">ContactUs id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> Delete(
		[FromServices] IContactUsDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
