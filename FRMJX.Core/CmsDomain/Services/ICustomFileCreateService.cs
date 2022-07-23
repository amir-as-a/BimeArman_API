namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using System.Threading.Tasks;

public interface ICustomFileCreateService
{
	Task<ServiceResult<int>> Create(CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto, CustomFileType customFileType, CancellationToken cancellationToken);
}
