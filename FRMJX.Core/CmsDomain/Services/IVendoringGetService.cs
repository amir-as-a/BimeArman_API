namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IVendoringGetService
{
	Task<ServiceResult<VendoringGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<VendoringGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<VendoringGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<VendoringGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken);

	Task<ServiceResult<List<VendoringGetResponseDto>>> GetByCity(int cityId, CancellationToken cancellationToken);
}
