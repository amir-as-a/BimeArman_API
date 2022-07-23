namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using System.Threading;
using System.Threading.Tasks;

public interface ICustomFileGetService
{
	Task<ServiceResult<CustomFileGetResponseDto>> GetById(int id, CustomFileType customFileType, CancellationToken cancellationToken);

	CustomFile GetModelById(int id, CustomFileType customFileType, CancellationToken cancellationToken);
}
