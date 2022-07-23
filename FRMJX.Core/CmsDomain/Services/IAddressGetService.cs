namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IAddressGetService
{
	Task<ServiceResult<AddressGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<AddressGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<AddressGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<AddressGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken);

	Task<ServiceResult<List<AddressGetResponseDto>>> GetByCity(int cityId, CancellationToken cancellationToken);
}
