namespace FRMJX.Infrastructure.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RoleDeleteService : IRoleDeleteService
{
	private readonly RoleManager<Role> roleManager;
	private readonly UserManager<User> userManager;

	public RoleDeleteService(
		RoleManager<Role> roleManager,
		UserManager<User> userManager)
	{
		this.roleManager = roleManager;
		this.userManager = userManager;
	}

	public async Task<ServiceResult> Delete(long id, long applicantUserId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var role = await roleManager.FindByIdAsync(id.ToString());
		if (role is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);

			return serviceResult;
		}

		var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);

		foreach (var user in usersInRole)
		{
			await userManager.RemoveFromRoleAsync(user, role.Name);
		}

		await roleManager.DeleteAsync(role);

		return serviceResult;
	}
}
