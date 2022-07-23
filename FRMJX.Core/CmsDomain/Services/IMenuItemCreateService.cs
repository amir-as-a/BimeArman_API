namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading.Tasks;

public interface IMenuItemCreateService
{
	Task<ServiceResult<int>> Create(MenuItemCreateAndUpdateRequestDto menuItemCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
