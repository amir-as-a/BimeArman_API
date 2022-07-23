namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Implementation;
using FRMJX.Core.Infrastructure.Framework.Extentions;
using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

internal class LocalApiSecuritySecurityService : ILocalApiSecuritySecurityService
{
	private readonly UserManager<User> userManager;
	private readonly IUserGetService userGetService;

	public LocalApiSecuritySecurityService(
		UserManager<User> userManager,
		IUserGetService userGetService)
	{
		this.userManager = userManager;
		this.userGetService = userGetService;
	}

	// TODO: Fetching mechanism in this service should be redesign using a cache mechanism
	public async Task<bool> CheckUserAccessBasedOnClaims(
		AccessLevelEnum maximumAccessLevel, string userName, SecurityClaimEnum[] requiredClaims)
	{
		var user = await userManager.FindByNameAsync(userName);

		var requiredClaimsDependencies = GetClaimsWithDependencies(requiredClaims.ToList());

		if (user is not null)
		{
			if (user.AccessLevel > maximumAccessLevel)
			{
				return false;
			}

			if (user.IsAppResponsible)
			{
				// Always return true for users with Programmer access level
				return true;
			}
			else
			{
				var allClaims = await userGetService.GetAllClaims(user);

				if (requiredClaimsDependencies.All(current => allClaims.Any(q => q.Value == current.ToString())))
				{
					return true;
				}
			}
		}

		return false;
	}

	public List<SecurityClaimEnum> GetClaimsWithDependencies(List<SecurityClaimEnum> claimEnums)
	{
		var result = new List<SecurityClaimEnum>();

		result.AddRange(claimEnums);

		foreach (var claim in claimEnums)
		{
			var dependencies = claim.GetAttribute<DependenciesAttribute>();

			if (dependencies is null)
			{
				result.Add(claim);
			}
			else
			{
				if (dependencies.Claims.Any())
				{
					result.AddRange(GetClaimsWithDependencies(dependencies.Claims));
				}
			}
		}

		return result.Distinct().ToList();
	}
}
