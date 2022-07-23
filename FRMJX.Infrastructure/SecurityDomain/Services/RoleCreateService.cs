namespace FRMJX.Infrastructure.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Dtos.Requests;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

internal class RoleCreateService : IRoleCreateService
{
	private readonly RoleManager<Role> roleManager;
	private readonly UserManager<User> userManager;
	private readonly IUserGetService userGetService;

	public RoleCreateService(RoleManager<Role> roleManager, UserManager<User> userManager, IUserGetService userGetService)
	{
		this.roleManager = roleManager;
		this.userManager = userManager;
		this.userGetService = userGetService;
	}

	public async Task<ServiceResult<long>> Create(
		long applicantUserId,
		Func<List<string>, (bool Result, List<(string Type, string Value)> Claims)> claimValidator,
		RoleCreateAndUpdateRequestDto request,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<long>();

		var existRole = await roleManager.FindByNameAsync(request.Name);
		if (existRole is not null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.BadRequest, "Role already exist");

			return serviceResult;
		}

		var claimValidationResult = claimValidator(request.SecurityClaims);
		if (claimValidationResult.Result is false)
		{
			serviceResult.SetStatusCode(HttpStatusCode.BadRequest, "Claim structure is not valid");

			return serviceResult;
		}

		var applicantUser = await userManager.FindByIdAsync(applicantUserId.ToString());

		if (applicantUser.IsAppResponsible is false)
		{
			var applicantUserClaims = await userGetService.GetAllClaims(applicantUser);
			var isThereAnyUnauthorizedClaim =
				request.SecurityClaims.All(current => applicantUserClaims.Where(q => q.Value == current).Any()) is false;

			if (isThereAnyUnauthorizedClaim)
			{
				serviceResult.SetStatusCode(HttpStatusCode.BadRequest, "Claim structure is not valid (based on authenticated user's calims)");

				return serviceResult;
			}
		}

		var role = new Role
		{
			Name = request.Name,
			Description = request.Description,
		};

		await roleManager.CreateAsync(role);

		serviceResult.Result = role.Id;

		foreach (var claim in claimValidationResult.Claims)
		{
			await roleManager.AddClaimAsync(role, new Claim(claim.Type, claim.Value));
		}

		if (applicantUser.IsAppResponsible is false)
		{
			await userManager.AddToRoleAsync(applicantUser, role.Name);
		}

		return serviceResult;
	}
}
