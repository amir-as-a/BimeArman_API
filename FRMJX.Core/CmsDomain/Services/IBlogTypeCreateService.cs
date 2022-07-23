namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading.Tasks;

public interface IBlogTypeCreateService
{
	Task<ServiceResult<int>> Create(BlogTypeCreateAndUpdateRequestDto blogTypeCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
