namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Dtos.Responses;
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
/// Home controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/common")]
[ApiExplorerSettings(GroupName = "Cms - Common")]
public class CommonController : BaseController
{
	/// <summary>
	/// Get Product And Blog
	/// </summary>
	/// <param name="getService">get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <param name="title">title</param>
	/// <returns>Founded Product And Blog </returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("Search")]
	[AllowAnonymous]
	public async Task<IActionResult> Search(
		[FromServices] ICommonGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken,
		string title) => await getService.Search(cultureLcid, pageIndex, pageSize, cancellationToken, title);
}
