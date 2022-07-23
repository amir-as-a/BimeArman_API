namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.SecurityDomain.Dtos.Requests;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using FRMJX.WebApi.Infrastructure.ModelBinders;
using FRMJX.WebApi.Infrastructure.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// AboutUs controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/PersonnelAndRepresentation")]
[ApiExplorerSettings(GroupName = "Cms - PersonnelAndRepresentation")]
public class PersonnelAndRepresentationController : BaseController
{
	/// <summary>
	/// Get all Representation
	/// </summary>
	/// <param name="getService">AboutUs get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <returns>Founded Representation</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("Representation")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> List(
		[FromServices] IUserGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize) => await getService.GetAllRepresention(cultureLcid, pageIndex, pageSize);

	/// <summary>
	/// Get All Personnel
	/// </summary>
	/// <param name="getService">AboutUs get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <returns>All Personnel</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("list/personnel")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] IUserGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize) => await getService.GetAllPersonnel(cultureLcid, pageIndex, pageSize);

	/// <summary>
	/// Delete Personnel And Representation
	/// </summary>
	/// <param name="deleteService">user edit service</param>
	/// <param name="localAuthService">token delete service</param>
	/// <param name="id">AboutUs id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] IUserDeleteService deleteService,
		[FromServices] ILocalAuthService localAuthService,
		int id,
		CancellationToken cancellationToken)
	{
		localAuthService.DeleteTokens(id);

		return await deleteService.Delete(id, cancellationToken);
	}

	/// <summary>
	/// Update Personnel And Representation
	/// </summary>
	/// <param name="deleteService">Update service</param>
	/// <param name="id">Personnel And Representation id</param>
	/// <param name="userRegisterDto">user model</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] IUserUpdateService deleteService,
		int id,
		UserRegisterDto userRegisterDto,
		CancellationToken cancellationToken) => await deleteService.Update(id, userRegisterDto, cancellationToken);

	/// <summary>
	/// get user By Id
	/// </summary>
	/// <param name="getService">get service</param>
	/// <param name="id">user id</param>
	/// <param name="cancellationToken">cancelation token</param>
	/// <returns>User Information</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] IUserGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);
}
