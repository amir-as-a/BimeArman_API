namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface ISettingGetService
{
	Task<ServiceResult<SettingGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<SettingGetResponseDto>> GetByName(int cultureLcid, string name, CancellationToken cancellationToken);

	Task<ServiceResult<List<SettingGetResponseDto>>> GetByNames(int cultureLcid, string[] names, CancellationToken cancellationToken);

	Task<ServiceResult<List<SettingGetResponseDto>>> Search(int cultureLcid, string q, CancellationToken cancellationToken);

	Task<ServiceResult<List<SettingGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken);
}
