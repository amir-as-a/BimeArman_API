namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IPersonnelPanelGetService
{
	Task<ServiceResult<PersonnelPanelGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<PersonnelPanelGetResponseDto>>> GetByCategoryId(int categoryId, int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<PersonnelPanelGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<PersonnelPanelGetResponseDto>>> GetAll(int cultureLcid,int? categoryId, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
