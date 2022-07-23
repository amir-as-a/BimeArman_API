namespace FRMJX.Infrastructure.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Dtos.Requests;
using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

internal class RoleUpdateService : IRoleUpdateService
{
	private readonly RoleManager<Role> roleManager;
	private readonly UserManager<User> userManager;
	private readonly IUserGetService userGetService;

	public RoleUpdateService(
		RoleManager<Role> roleManager,
		UserManager<User> userManager,
		IUserGetService userGetService)
	{
		this.roleManager = roleManager;
		this.userManager = userManager;
		this.userGetService = userGetService;
	}

	public async Task<ServiceResult> Update(
		long id,
		long applicantUserId,
		Func<List<string>, (bool Result, List<(string Type, string Value)> Claims)> claimValidator,
		RoleCreateAndUpdateRequestDto request,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var role = await roleManager.FindByIdAsync(id.ToString());
		if (role is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);

			return serviceResult;
		}

		var existRole = await roleManager.Roles
			.Where(current => current.Id != role.Id)
			.SingleOrDefaultAsync(current => current.Name == request.Name, cancellationToken);
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

		role.Name = request.Name;
		role.Description = request.Description;

		await roleManager.UpdateAsync(role);

		var roleClaims = await roleManager.GetClaimsAsync(role);

		// Removing redundant security claims and add new ones
		var securityClaimForRemove = roleClaims
			.Where(current => current.Type == nameof(ClaimTypeEnum.Security))
			.Where(current => claimValidationResult.Claims
				.Where(q => q.Value == current.Value)
				.Where(q => q.Type == current.Type)
				.Any() is false)
			.ToList();

		foreach (var securityClaim in securityClaimForRemove)
		{
			await roleManager.RemoveClaimAsync(role, new Claim(securityClaim.Type, securityClaim.Value));
		}

		foreach (var securityClaim in claimValidationResult.Claims)
		{
			var roleClaimNotExist = roleClaims
				.Where(current => current.Type == securityClaim.Type)
				.Where(current => current.Value == securityClaim.Value)
				.Any() is false;

			if (roleClaimNotExist)
			{
				await roleManager.AddClaimAsync(role, new Claim(securityClaim.Type, securityClaim.Value));
			}
		}

		return serviceResult;
	}
}
