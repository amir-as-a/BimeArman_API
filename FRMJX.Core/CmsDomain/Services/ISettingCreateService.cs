namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading.Tasks;

public interface ISettingCreateService
{
	Task<ServiceResult<int>> Create(SettingCreateAndUpdateRequestDto settingCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
