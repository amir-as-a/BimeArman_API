namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IRepresentativePanelGetService
{
	Task<ServiceResult<RepresentativePanelGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentativePanelGetResponseDto>>> GetByCategoryId(int categoryId, int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentativePanelGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentativePanelGetResponseDto>>> GetAll(int cultureLcid, int? categoryId, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
