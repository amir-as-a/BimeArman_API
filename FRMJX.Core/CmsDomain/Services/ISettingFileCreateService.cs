namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading.Tasks;

public interface ISettingFileCreateService
{
	Task<ServiceResult<int>> Create(SettingFileCreateAndUpdateRequestDto settingFileCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
