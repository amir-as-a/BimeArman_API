namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IHealthCenterGetService
{
	Task<ServiceResult<HealthCenterGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<HealthCenterGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<HealthCenterGetResponseDto>>> GetAll(int cultureLcid, int? stateId, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<HealthCenterGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken);
}
