namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IRepresentativePanelCategoryGetService
{
	Task<ServiceResult<RepresentativePanelCategoryGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentativePanelCategoryGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<RepresentativePanelCategoryGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
