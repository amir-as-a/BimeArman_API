namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface ISettingUpdateService
{
	Task<ServiceResult> Update(int id, SettingCreateAndUpdateRequestDto settingCreateAndUpdateDto, CancellationToken cancellationToken);
}
