namespace FRMJX.Infrastructure.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

internal class UserSeedService : IUserSeedService
{
	private readonly UserManager<User> userManager;

	public UserSeedService(UserManager<User> userManager)
	{
		this.userManager = userManager;
	}

	public async Task<ServiceResult> Initialize()
	{
		var serviceResult = new ServiceResult();

		var password = "Aa123456#";

		var kadmin = await userManager.FindByNameAsync("kadmin");

		if (kadmin is null)
		{
			kadmin = new User
			{
				UserName = "SAdmin",
				Email = "sadmin@faramouj.ir",
				PhoneNumber = "+989121111111",
				FirstName = "Super",
				LastName = "Administrator",
				IsActive = true,
				IsDeleted = false,
				AccessLevel = AccessLevelEnum.SuperAdmin,
			};

			await userManager.CreateAsync(kadmin, password);
		}

		return serviceResult;
	}
}
