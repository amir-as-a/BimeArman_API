namespace FRMJX.WebApi.Infrastructure.Services.Implementation;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.WebApi.Infrastructure.ApiSecurity;
using FRMJX.WebApi.Infrastructure.Dtos;
using FRMJX.WebApi.Infrastructure.Services.Abstraction;
using System.Threading;
using System.Threading.Tasks;

internal class LocalUserService : ILocalUserService
{
	private readonly IUserInformationService userInformationService;

	public LocalUserService(IUserInformationService userInformationService)
	{
		this.userInformationService = userInformationService;
	}

	public async Task<ServiceResult<AuthenticatedUserDto>> GetUserInformation(long userId, CancellationToken cancellationToken)
	{
		var userGetServiceResult = await userInformationService.Get(userId, cancellationToken);

		var serviceResult = new ServiceResult<AuthenticatedUserDto>
		{
			Result = new()
			{
				FirstName = userGetServiceResult.Result.FirstName,
				LastName = userGetServiceResult.Result.LastName,
				UserName = userGetServiceResult.Result.UserName,
				PhoneNumber = userGetServiceResult.Result.PhoneNumber,
				Email = userGetServiceResult.Result.Email,
				AccessLevel = userGetServiceResult.Result.AccessLevel,
				SecurityClaims = userGetServiceResult.Result.Claims.ToSecurityClaims(),
			},
		};

		return serviceResult;
	}
}
