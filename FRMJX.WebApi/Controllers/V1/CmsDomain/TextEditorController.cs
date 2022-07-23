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
/// TextEditor controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/textEditor")]
[ApiExplorerSettings(GroupName = "Cms - TextEditors")]
public class TextEditorsController : BaseController
{
	/// <summary>
	/// Get textEditor by id
	/// </summary>
	/// <param name="getService">TextEditor get service</param>
	/// <param name="id">TextEditor id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded textEditor</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] ITextEditorGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get textEditors by pageTitle
	/// </summary>
	/// <param name="getService">TextEditor get service</param>
	/// <param name="pageTitle">TextEditor pageTitle</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded textEditors</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("List/{pageTitle}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] ITextEditorGetService getService,
		string pageTitle,
		CancellationToken cancellationToken) => await getService.GetByPageTitle(pageTitle, cancellationToken);

	/// <summary>
	/// Get all textEditors
	/// </summary>
	/// <param name="getService">TextEditor get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded textEditors</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] ITextEditorGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active textEditors
	/// </summary>
	/// <param name="getService">TextEditor get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active textEditors</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] ITextEditorGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Create textEditor
	/// </summary>
	/// <param name="createService">TextEditor create service</param>
	/// <param name="textEditorCreateAndUpdateDto">TextEditor create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created textEditor</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] ITextEditorCreateService createService,
		TextEditorCreateAndUpdateRequestDto textEditorCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(textEditorCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit textEditor
	/// </summary>
	/// <param name="updateService">TextEditor update service</param>
	/// <param name="textEditorCreateAndUpdateDto">TextEditor create and update dto</param>
	/// <param name="id">TextEditor id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] ITextEditorUpdateService updateService,
		TextEditorCreateAndUpdateRequestDto textEditorCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, textEditorCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete textEditor
	/// </summary>
	/// <param name="deleteService">TextEditor edit service</param>
	/// <param name="id">TextEditor id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] ITextEditorDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
