namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using System.Threading;
using System.Threading.Tasks;

public interface ICustomFileUpdateService
{
	Task<ServiceResult> Update(int id, CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto, CustomFileType customFileType, CancellationToken cancellationToken);
}
