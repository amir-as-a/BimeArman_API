namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface ISettingFileGetService
{
	Task<ServiceResult<SettingFileGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<SettingFileGetResponseDto>>> GetByNames(int cultureLcid, string[] names, CancellationToken cancellationToken);

	Task<ServiceResult<List<SettingFileGetResponseDto>>> Search(int cultureLcid, string q, CancellationToken cancellationToken);

	Task<ServiceResult<List<SettingFileGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken);
}
