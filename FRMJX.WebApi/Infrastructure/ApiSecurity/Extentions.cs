namespace FRMJX.WebApi.Infrastructure.ApiSecurity;

using FRMJX.Core.Infrastructure.Framework.Extentions;
using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

internal static class Extentions
{
	public static List<SecurityClaimDto> ToSecurityClaims(this IEnumerable<Claim> claims)
	{
		var result = new List<SecurityClaimDto>();

		foreach (var claim in claims.Where(current => current.Type == nameof(ClaimTypeEnum.Security)))
		{
			if (Enum.TryParse(claim.Value, out SecurityClaimEnum claimEnum))
			{
				result.Add(new()
				{
					Value = claimEnum.ToString(),
					Dependencies = claimEnum.GetAttribute<DependenciesAttribute>()?.Claims.Select(current => current.ToString()).ToList() ?? new List<string>(),
				});
			}
		}

		return result;
	}
}
