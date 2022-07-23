namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IMenuItemUpdateService
{
	Task<ServiceResult> Update(int id, MenuItemCreateAndUpdateRequestDto menuItemCreateAndUpdateDto, CancellationToken cancellationToken);
}
