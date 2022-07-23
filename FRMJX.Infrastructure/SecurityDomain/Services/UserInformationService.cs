namespace FRMJX.Infrastructure.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Dtos.Responses;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class UserInformationService : IUserInformationService
{
	private readonly UserManager<User> userManager;
	private readonly DatabaseContext databaseContext;
	private readonly IUserGetService userGetService;

	public UserInformationService(
		UserManager<User> userManager,
		IUserGetService userGetService,
		DatabaseContext databaseContext)
	{
		this.userManager = userManager;
		this.userGetService = userGetService;
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<UserGetInformationResponseDto>> Get(long userId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<UserGetInformationResponseDto>();

		var user = await userManager.FindByIdAsync(userId.ToString());

		if (user is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);

			return serviceResult;
		}

		var claims = await userGetService.GetAllClaims(user);

		serviceResult = new ServiceResult<UserGetInformationResponseDto>
		{
			Result = new()
			{
				Email = user.Email,
				UserName = user.UserName,
				FirstName = user.FirstName,
				LastName = user.LastName,
				AccessLevel = user.AccessLevel,
				PhoneNumber = user.PhoneNumber,
				Claims = claims,
			},
		};

		return serviceResult;
	}

	public async Task<ServiceResult<UserGetInformationResponseDto>> GetById(int userId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<UserGetInformationResponseDto>();

		var user = await databaseContext.Users
			.Where(current => current.Id == userId)
			.SingleOrDefaultAsync(cancellationToken);

		if (user is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);

			return serviceResult;
		}

		var claims = await userGetService.GetAllClaims(user);

		serviceResult = new ServiceResult<UserGetInformationResponseDto>
		{
			Result = new()
			{
				Email = user.Email,
				UserName = user.UserName,
				FirstName = user.FirstName,
				LastName = user.LastName,
				AccessLevel = user.AccessLevel,
				PhoneNumber = user.PhoneNumber,
				Claims = claims,
			},
		};

		return serviceResult;
	}
}
