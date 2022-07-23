namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IRevelationAttributeGetService
{
	Task<ServiceResult<RevelationAttributeGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<RevelationAttributeGetResponseDto>>> GetByRevelationId(int revelationId, CancellationToken cancellationToken);

	Task<ServiceResult<List<RevelationAttributeGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<RevelationAttributeGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
