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
/// Pdf controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/pdf")]
[ApiExplorerSettings(GroupName = "Cms - Pdfs")]
public class PdfsController : BaseController
{
	/// <summary>
	/// Get pdfs by id
	/// </summary>
	/// <param name="getService">Pdf get service</param>
	/// <param name="id">Pdf id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded pdf</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IPdfGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all pdfs
	/// </summary>
	/// <param name="getService">Pdf get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded pdfs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IPdfGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active pdfs
	/// </summary>
	/// <param name="getService">Pdf get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active pdfs</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IPdfGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create pdf
	/// </summary>
	/// <param name="createService">Pdf create service</param>
	/// <param name="pdfCreateAndUpdateDto">Pdf create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created pdf</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] IPdfCreateService createService,
		PdfCreateAndUpdateRequestDto pdfCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(pdfCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit pdf
	/// </summary>
	/// <param name="updateService">Pdf update service</param>
	/// <param name="pdfCreateAndUpdateDto">Pdf create and update dto</param>
	/// <param name="id">Pdf id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IPdfUpdateService updateService,
		PdfCreateAndUpdateRequestDto pdfCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, pdfCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete pdf
	/// </summary>
	/// <param name="deleteService">Pdf edit service</param>
	/// <param name="id">Pdf id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IPdfDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
