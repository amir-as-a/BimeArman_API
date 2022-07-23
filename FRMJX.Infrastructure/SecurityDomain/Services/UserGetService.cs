namespace FRMJX.Infrastructure.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Dtos.Responses;
using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

internal class UserGetService : IUserGetService
{
	private readonly UserManager<User> userManager;
	private readonly RoleManager<Role> roleManager;
	private readonly DatabaseContext databaseContext;

	public UserGetService(
		UserManager<User> userManager,
		RoleManager<Role> roleManager,
		DatabaseContext databaseContext)
	{
		this.userManager = userManager;
		this.roleManager = roleManager;
		this.databaseContext = databaseContext;
	}

	public async Task<IEnumerable<Claim>> GetAllClaims(User user)
	{
		var roles = await userManager.GetRolesAsync(user);

		var userClaims = await userManager.GetClaimsAsync(user);
		var roleClaims = new List<Claim>();

		foreach (var role in roles)
		{
			var roleFromStore = await roleManager.FindByNameAsync(role);
			var currentRoleClaims = await roleManager.GetClaimsAsync(roleFromStore);
			roleClaims.AddRange(currentRoleClaims);
		}

		var allClaims = roleClaims.Union(userClaims.ToList());

		return allClaims;
	}

	public async Task<ServiceResult<List<UserGetInformationResponseDto>>> GetAllRepresention(int cultureLcid, int pageIndex, int pageSize)
	{
		var serviceResult = new ServiceResult<List<UserGetInformationResponseDto>>();

		var users = databaseContext.Users
			.Where(current => current.AccessLevel == (AccessLevelEnum)Enum.ToObject(typeof(AccessLevelEnum), 400) && current.IsDeleted == false)
			.OrderBy(current => current.Id)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToList();

		serviceResult.Result = users
			.Select(current => new UserGetInformationResponseDto
			{
				Id = current.Id,
				UserName = current.UserName,
				Email = current.Email,
				FirstName = current.FirstName,
				LastName = current.LastName,
				PhoneNumber = current.PhoneNumber,
				AccessLevel = current.AccessLevel,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<UserGetInformationResponseDto>>> GetAllPersonnel(int cultureLcid, int pageIndex, int pageSize)
	{
		var serviceResult = new ServiceResult<List<UserGetInformationResponseDto>>();

		var users = databaseContext.Users
			.Where(current => current.AccessLevel == (AccessLevelEnum)Enum.ToObject(typeof(AccessLevelEnum), 500) && current.IsDeleted == false)
			.OrderBy(current => current.Id)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToList();

		serviceResult.Result = users
			.Select(current => new UserGetInformationResponseDto
			{
				Id = current.Id,
				UserName = current.UserName,
				Email = current.Email,
				FirstName = current.FirstName,
				LastName = current.LastName,
				PhoneNumber = current.PhoneNumber,
				AccessLevel = current.AccessLevel,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<UserGetInformationResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<UserGetInformationResponseDto>();

		var user = await databaseContext.Users
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);
		if (user != null)
		{

			serviceResult.Result = new UserGetInformationResponseDto()
			{
				Id = user.Id,
				UserName = user.UserName,
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				AccessLevel = user.AccessLevel,
			};
		}

		return serviceResult;
	}
}
