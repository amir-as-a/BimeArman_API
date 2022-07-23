namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Setting controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/setting")]
[ApiExplorerSettings(GroupName = "Cms - Settings")]
public class SettingsController : BaseController
{
	/// <summary>
	/// Get setting by id
	/// </summary>
	/// <param name="getService">Setting get service</param>
	/// <param name="cultureLcid">Setting culture lcid</param>
	/// <param name="name">Setting name</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded setting</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{name}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetByName(
		[FromServices] ISettingGetService getService,
		[FromHeader] int cultureLcid,
		string name,
		CancellationToken cancellationToken) => await getService.GetByName(cultureLcid, name, cancellationToken);

	/// <summary>
	/// Get all settings
	/// </summary>
	/// <param name="getService">Setting get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded settings</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] ISettingGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, cancellationToken);

	/// <summary>
	/// Search settings
	/// </summary>
	/// <param name="getService">Setting get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="q">q</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active settings</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("search/{q}")]
	[ApiSecurity(SecurityClaimEnum.CmsModule)]
	public async Task<IActionResult> GetByNames(
		[FromServices] ISettingGetService getService,
		[FromHeader] int cultureLcid,
		string q,
		CancellationToken cancellationToken) => await getService.Search(cultureLcid, q, cancellationToken);

	/// <summary>
	/// Create setting
	/// </summary>
	/// <param name="createService">Setting create service</param>
	/// <param name="settingCreateAndUpdateDto">Setting create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created setting</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] ISettingCreateService createService,
		SettingCreateAndUpdateRequestDto settingCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(settingCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit setting
	/// </summary>
	/// <param name="updateService">Setting update service</param>
	/// <param name="settingCreateAndUpdateDto">Setting create and update dto</param>
	/// <param name="id">Setting id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] ISettingUpdateService updateService,
		SettingCreateAndUpdateRequestDto settingCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, settingCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete setting
	/// </summary>
	/// <param name="deleteService">Setting edit service</param>
	/// <param name="id">Setting id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] ISettingDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
