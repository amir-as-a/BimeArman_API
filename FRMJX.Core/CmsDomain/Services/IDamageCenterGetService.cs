namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IDamageCenterGetService
{
	Task<ServiceResult<DamageCenterGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<DamageCenterGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<DamageCenterGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<DamageCenterGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken);

	Task<ServiceResult<List<DamageCenterGetResponseDto>>> GetByCity(int cityId, CancellationToken cancellationToken);
}
