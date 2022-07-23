namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IInsuranceInfoGetService
{
	Task<ServiceResult<InsuranceInfoGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<InsuranceInfoGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<InsuranceInfoGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<InsuranceInfoGetResponseDto>>> GetByInsuranceId(int insuranceId, CancellationToken cancellationToken);
}
