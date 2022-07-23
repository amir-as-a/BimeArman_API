namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IPersonnelPanelCategoryGetService
{
	Task<ServiceResult<PersonnelPanelCategoryGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<PersonnelPanelCategoryGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<PersonnelPanelCategoryGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
