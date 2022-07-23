namespace FRMJX.Core.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Dtos.Responses;
using System.Threading;
using System.Threading.Tasks;

public interface IUserInformationService
{
	Task<ServiceResult<UserGetInformationResponseDto>> Get(long userId, CancellationToken cancellationToken);

	Task<ServiceResult<UserGetInformationResponseDto>> GetById(int userId, CancellationToken cancellationToken);
}
