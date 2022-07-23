namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IInsuranceGetService
{
	Task<ServiceResult<InsuranceGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<InsuranceGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<InsuranceGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken, string? title = null);
}
