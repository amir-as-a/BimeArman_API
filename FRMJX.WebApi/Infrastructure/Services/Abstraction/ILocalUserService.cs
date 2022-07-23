namespace FRMJX.WebApi.Infrastructure.Services.Abstraction;

using FRMJX.Core.Infrastructure;
using FRMJX.WebApi.Infrastructure.Dtos;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Local user service
/// </summary>
public interface ILocalUserService
{
	/// <summary>
	/// Get User information
	/// </summary>
	/// <param name="userId">User Id</param>
	/// <param name="cancellationToken">Cancellation Token</param>
	/// <returns>Authenticated User</returns>
	Task<ServiceResult<AuthenticatedUserDto>> GetUserInformation(long userId, CancellationToken cancellationToken);
}
