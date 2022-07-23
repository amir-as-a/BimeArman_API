namespace FRMJX.WebApi.Infrastructure.Extentions;

using System;
using System.Security.Claims;

internal static class ClaimsPrincipalExtension
{
	public static int GetAuthenticatedUserId(this ClaimsPrincipal principal)
	{
		if (principal == null)
		{
			throw new ArgumentNullException(nameof(principal));
		}

		var authenticatedUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

		return Convert.ToInt32(authenticatedUserId);
	}
}
