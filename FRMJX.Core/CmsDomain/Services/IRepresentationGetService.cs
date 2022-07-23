namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IRepresentationGetService
{
	Task<ServiceResult<RepresentationGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentationGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentationGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentationGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentationGetResponseDto>>> GetByCity(int cityId, CancellationToken cancellationToken);
}
