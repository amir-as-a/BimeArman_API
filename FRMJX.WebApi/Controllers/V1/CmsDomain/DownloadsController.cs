namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure.Enums;
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
/// Download controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/download")]
[ApiExplorerSettings(GroupName = "Cms - Downloads")]
public class DownloadsController : BaseController
{
	/// <summary>
	/// Get downloads by id
	/// </summary>
	/// <param name="getService">custom file get service</param>
	/// <param name="fileId">file id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded downloads</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{fileId}")]
	[AllowAnonymous]
	public IActionResult GetFile(
		[FromServices] ICustomFileGetService getService,
		[FromQuery] int fileId,
		CancellationToken cancellationToken)
	{
		var file = getService.GetModelById(fileId, CustomFileType.File, cancellationToken);
		if (file == null)
		{
			return NotFound();
		}

		return File(file.Content, file.ContentType, file.Name);
	}
}
