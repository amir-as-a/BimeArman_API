namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IBlogCommentGetService
{
	Task<ServiceResult<List<BlogCommentGetResponseDto>>> GetByIds(int[] ids, CancellationToken cancellationToken);

	Task<ServiceResult<BlogCommentGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogCommentGetResponseDto>>> GetByBlogId(int blogPostId, int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogCommentGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogCommentGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
