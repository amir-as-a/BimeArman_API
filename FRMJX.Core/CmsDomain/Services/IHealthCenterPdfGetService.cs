namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IHealthCenterPdfGetService
{
	Task<ServiceResult<HealthCenterPdfGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<HealthCenterPdfGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<HealthCenterPdfGetResponseDto>>> GetAll(int cultureLcid, int? stateId, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<HealthCenterPdfGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken);
}
