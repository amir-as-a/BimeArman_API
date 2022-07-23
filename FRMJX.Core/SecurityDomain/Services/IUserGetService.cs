namespace FRMJX.Core.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Dtos.Responses;
using FRMJX.Core.SecurityDomain.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

public interface IUserGetService
{
	Task<IEnumerable<Claim>> GetAllClaims(User user);

	Task<ServiceResult<List<UserGetInformationResponseDto>>> GetAllRepresention(int cultureLcid, int pageIndex, int pageSize);

	Task<ServiceResult<List<UserGetInformationResponseDto>>> GetAllPersonnel(int cultureLcid, int pageIndex, int pageSize);

	Task<ServiceResult<UserGetInformationResponseDto>> GetById(int id, CancellationToken cancellationToken);
}
