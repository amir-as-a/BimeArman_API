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
/// Faq controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/faq")]
[ApiExplorerSettings(GroupName = "Cms - Faqs")]
public class FaqsController : BaseController
{
	/// <summary>
	/// Get faqs by id
	/// </summary>
	/// <param name="getService">Faq get service</param>
	/// <param name="id">Faq id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded faq</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IFaqGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all faqs
	/// </summary>
	/// <param name="getService">Faq get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded faqs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IFaqGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active faqs
	/// </summary>
	/// <param name="getService">Faq get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active faqs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IFaqGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create faq
	/// </summary>
	/// <param name="createService">Faq create service</param>
	/// <param name="faqCreateAndUpdateDto">Faq create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created faq</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IFaqCreateService createService,
		FaqCreateAndUpdateRequestDto faqCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(faqCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit faq
	/// </summary>
	/// <param name="updateService">Faq update service</param>
	/// <param name="faqCreateAndUpdateDto">Faq create and update dto</param>
	/// <param name="id">Faq id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IFaqUpdateService updateService,
		FaqCreateAndUpdateRequestDto faqCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, faqCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete faq
	/// </summary>
	/// <param name="deleteService">Faq edit service</param>
	/// <param name="id">Faq id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IFaqDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
