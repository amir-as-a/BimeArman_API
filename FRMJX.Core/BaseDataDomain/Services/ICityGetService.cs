namespace FRMJX.Core.BaseDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface ICityGetService
{
	Task<ServiceResult<CityGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<CityGetResponseDto>>> GetActives(CancellationToken cancellationToken);

	Task<ServiceResult<List<CityGetResponseDto>>> GetAll(CancellationToken cancellationToken);

	Task<ServiceResult<List<CityGetResponseDto>>> GetByStateId(int stateId, CancellationToken cancellationToken);
}
