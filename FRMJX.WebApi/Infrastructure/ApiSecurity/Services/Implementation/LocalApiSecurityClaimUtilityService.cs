namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Implementation;

using FRMJX.Core.Infrastructure.Framework.Extentions;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

internal class LocalApiSecurityClaimUtilityService : ILocalApiSecurityClaimUtilityService
{
	private readonly ILocalApiSecuritySecurityService localApiSecuritySecurityService;

	public LocalApiSecurityClaimUtilityService(ILocalApiSecuritySecurityService localApiSecuritySecurityService)
	{
		this.localApiSecuritySecurityService = localApiSecuritySecurityService;
	}

	public (bool Result, List<(string Type, string Value)>? Claims) ValidateClaims(List<string> claimValues)
	{
		var result = new List<(string Type, string Value)>();

		var claims = new List<SecurityClaimEnum>();

		foreach (var claimValue in claimValues)
		{
			var convertReuslt = Enum.TryParse(claimValue, out SecurityClaimEnum claim);

			if (convertReuslt is false)
			{
				return (false, null);
			}

			claims.Add(claim);

			result.Add(new(claim.GetAttributeFromEnumType<TypeAttribute>().Type.ToString(), claimValue));
		}

		var allClaimWithDependencies = localApiSecuritySecurityService.GetClaimsWithDependencies(claims);

		if (allClaimWithDependencies.All(claims.Contains) is false)
		{
			return (false, null);
		}

		return (true, result);
	}
}
