namespace FRMJX.WebApi.Infrastructure.ApiSecurity.ActionFilters;

using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

internal class BaseApiSecurityActionFilter : IAsyncAuthorizationFilter
{
	public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
	{
		var apiSeurityAttribute = (ApiSecurityAttribute)context.ActionDescriptor.EndpointMetadata
			.Where(endpointMetadata => endpointMetadata.GetType() == typeof(ApiSecurityAttribute))
			.SingleOrDefault();

		var hasAllowAnonymousAttribute = context.ActionDescriptor.EndpointMetadata
			.Any(endpointMetadata => endpointMetadata.GetType() == typeof(AllowAnonymousAttribute));

		// In the absence of the ApiSecurityAttribute,
		// no one can access the action if the AllowAnonymousAttribute is not written explicitly
		if (apiSeurityAttribute is null)
		{
			if (hasAllowAnonymousAttribute is false)
			{
				context.Result = new ForbidResult();
			}
		}

		// Otherwise, The investigation of security cases is based on properties of the ApiSecurityAttribute
		else
		{
			if (context.HttpContext.User.Identity.IsAuthenticated is false)
			{
				context.Result = new ForbidResult();
			}
			else
			{
				var localApiSecuritySecurityService = context.HttpContext.RequestServices.GetService<ILocalApiSecuritySecurityService>();

				var result = await localApiSecuritySecurityService
					.CheckUserAccessBasedOnClaims(
						maximumAccessLevel: apiSeurityAttribute.MaximumAccessLevel,
						userName: context.HttpContext.User.Identity.Name,
						requiredClaims: apiSeurityAttribute.RequiredClaims);

				if (result is false)
				{
					context.Result = new ForbidResult();
				}
			}
		}
	}
}
