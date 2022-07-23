namespace FRMJX.Core.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Framework.Dtos.Grid;
using FRMJX.Core.SecurityDomain.Dtos.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IRoleGetService
{
	Task<ServiceResult<GridResultDto<RoleGetWithPagingResponseDto>>> Get(int applicantUserId, GridFilterDto gridFilterDto, CancellationToken cancellationToken);

	Task<ServiceResult<List<RoleGetResponseDto>>> GetAll(int applicantUserId, CancellationToken cancellationToken);

	Task<ServiceResult<RoleGetDetailResponseDto>> GetById(int applicantUserId, int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<int>>> GetValidRoles(int userId, CancellationToken cancellationToken);
}
