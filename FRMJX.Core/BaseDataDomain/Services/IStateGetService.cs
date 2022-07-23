namespace FRMJX.Core.BaseDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IStateGetService
{
	Task<ServiceResult<StateGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<StateGetResponseDto>>> GetActives(CancellationToken cancellationToken);

	Task<ServiceResult<List<StateGetResponseDto>>> GetAll(CancellationToken cancellationToken);
}
