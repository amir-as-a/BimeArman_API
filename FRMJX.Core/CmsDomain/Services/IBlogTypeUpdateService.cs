namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IBlogTypeUpdateService
{
	Task<ServiceResult> Update(int id, BlogTypeCreateAndUpdateRequestDto blogTypeCreateAndUpdateDto, CancellationToken cancellationToken);
}
