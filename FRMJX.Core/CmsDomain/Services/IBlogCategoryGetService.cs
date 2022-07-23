namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IBlogCategoryGetService
{
	Task<ServiceResult<BlogCategoryGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogCategoryGetResponseDto>>> GetActives(int cultureLcid, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogCategoryGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken);
}
