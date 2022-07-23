namespace FRMJX.WebApi.Infrastructure;

using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.Attributes.ResponseHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Project base controller
/// </summary>
[Authorize]
[ApiController]
[BaseApiSecurity]
[XApiResponse]
public class BaseController : ControllerBase
{
}
