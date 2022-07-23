namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using FRMJX.WebApi.Infrastructure.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// SettingFile controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/settingFile")]
[ApiExplorerSettings(GroupName = "Cms - SettingFiles")]
public class SettingFilesController : BaseController
{
	/// <summary>
	/// Get settingFile by id
	/// </summary>
	/// <param name="getService">SettingFile get service</param>
	/// <param name="id">SettingFile id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded settingFiles</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> GetById(
		[FromServices] ISettingFileGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all settingFiles
	/// </summary>
	/// <param name="getService">SettingFile get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded settingFiles</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> List(
		[FromServices] ISettingFileGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, cancellationToken);

	/// <summary>
	/// Get settingFiles by names
	/// </summary>
	/// <param name="getService">SettingFile get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="names">settingFile names</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active settingFiles</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("List/{names}")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> GetByNames(
		[FromServices] ISettingFileGetService getService,
		[FromHeader] int cultureLcid,
		[FromCommaDelimited] string[] names,
		CancellationToken cancellationToken) => await getService.GetByNames(cultureLcid, names, cancellationToken);

	/// <summary>
	/// Search settingFiles
	/// </summary>
	/// <param name="getService">SettingFile get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="q">q</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active settingFiles</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("search/{q}")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> GetByNames(
		[FromServices] ISettingFileGetService getService,
		[FromHeader] int cultureLcid,
		string q,
		CancellationToken cancellationToken) => await getService.Search(cultureLcid, q, cancellationToken);

	/// <summary>
	/// Create settingFile
	/// </summary>
	/// <param name="createService">SettingFile create service</param>
	/// <param name="settingFileCreateAndUpdateDto">SettingFile create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created settingFile</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] ISettingFileCreateService createService,
		SettingFileCreateAndUpdateRequestDto settingFileCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(settingFileCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit settingFile
	/// </summary>
	/// <param name="updateService">SettingFile update service</param>
	/// <param name="settingFileCreateAndUpdateDto">SettingFile create and update dto</param>
	/// <param name="id">SettingFile id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] ISettingFileUpdateService updateService,
		SettingFileCreateAndUpdateRequestDto settingFileCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, settingFileCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete settingFile
	/// </summary>
	/// <param name="deleteService">SettingFile edit service</param>
	/// <param name="id">SettingFile id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] ISettingFileDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
