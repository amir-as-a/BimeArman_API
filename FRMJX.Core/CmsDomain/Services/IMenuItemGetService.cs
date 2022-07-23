namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IMenuItemGetService
{
	Task<ServiceResult<MenuItemGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<MenuItemGetResponseDto>>> GetActivesByParentId(int cultureLcid, int? parentId, CancellationToken cancellationToken);

	Task<ServiceResult<List<MenuItemGetResponseDto>>> GetActives(int cultureLcid, CancellationToken cancellationToken, int? parentId = null);

	Task<ServiceResult<List<MenuItemGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken, int? parentId = null);

	Task<ServiceResult<List<MenuItemGetResponseDto>>> GetByParentId(int cultureLcid, int? parentId, CancellationToken cancellationToken);

	Task<ServiceResult<List<MenuItemGetResponseDto>>> GetMenuItem(int cultureLcid, CancellationToken cancellationToken);

	Task<ServiceResult<List<MenuItemGetResponseDto>>> GetFirstFooter(int cultureLcid, CancellationToken cancellationToken);

	Task<ServiceResult<List<MenuItemGetResponseDto>>> GetSecendFooter(int cultureLcid, CancellationToken cancellationToken);

	Task<ServiceResult<List<MenuItemGetResponseDto>>> GetThirdFooter(int cultureLcid, CancellationToken cancellationToken);
}
