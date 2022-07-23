namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading.Tasks;

public interface IBlogCategoryCreateService
{
	Task<ServiceResult<int>> Create(BlogCategoryCreateAndUpdateRequestDto blogTypeCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
