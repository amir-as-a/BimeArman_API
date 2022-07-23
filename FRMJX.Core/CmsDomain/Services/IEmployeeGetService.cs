namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IEmployeeGetService
{
	Task<ServiceResult<EmployeeGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<EmployeeGetResponseDto>>> GetByNationalCode(string nationalCode, CancellationToken cancellationToken);

	Task<ServiceResult<List<EmployeeGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<EmployeeGetResponseDto>>> GetAll(int cultureLcid, int? positionId, string? nationalCode, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<EmployeeGetResponseDto>>> GetByPositionId(int positionId, CancellationToken cancellationToken);
}
