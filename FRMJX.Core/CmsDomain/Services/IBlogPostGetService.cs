namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IBlogPostGetService
{
	Task<ServiceResult<BlogPostGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogPostGetResponseDto>>> GetActives(int cultureLcid, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogPostGetResponseDto>>> GetAll(int cultureLcid, bool isActive, CancellationToken cancellationToken, string? title = null);

	Task<ServiceResult<List<BlogPostGetResponseDto>>> GetlastBlogs(int cultureLcid, CancellationToken cancellationToken);
}
