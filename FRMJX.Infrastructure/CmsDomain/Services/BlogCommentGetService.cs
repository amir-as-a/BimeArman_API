namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class BlogCommentGetService : IBlogCommentGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IUserGetService userGetService;

	public BlogCommentGetService(DatabaseContext databaseContext, IUserGetService userGetService)
	{
		this.databaseContext = databaseContext;
		this.userGetService = userGetService;
	}

	public async Task<ServiceResult<List<BlogCommentGetResponseDto>>> GetByIds(int[] ids, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogCommentGetResponseDto>>();

		var blogComments = await databaseContext.BlogComment
			.Where(current => ids.Contains(current.Id))
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogComments
			.Select(current => new BlogCommentGetResponseDto
			{
				Id = current.Id,
				FirstName = current.FirstName,
				LastName = current.LastName,
				ConfirmedByAdmin = current.ConfirmedByAdmin,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				BlogPostId = current.BlogPostId,
				Comment = current.Comment,
				InsertDateTime = current.InsertDateTime,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<BlogCommentGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<BlogCommentGetResponseDto>();

		var blogComment = await databaseContext.BlogComment
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (blogComment != null)
		{
			serviceResult.Result = new BlogCommentGetResponseDto
			{
				Id = blogComment.Id,
				FirstName = blogComment.FirstName,
				LastName = blogComment.LastName,
				ConfirmedByAdmin = blogComment.ConfirmedByAdmin,
				Ordering = blogComment.Ordering,
				IsActive = blogComment.IsActive,
				BlogPostId = blogComment.BlogPostId,
				Comment = blogComment.Comment,
				InsertDateTime = blogComment.InsertDateTime,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogCommentGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogCommentGetResponseDto>>();

		var blogComments = await databaseContext.BlogComment
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogComments
			.Select(current => new BlogCommentGetResponseDto
			{
				Id = current.Id,
				FirstName = current.FirstName,
				LastName = current.LastName,
				ConfirmedByAdmin = current.ConfirmedByAdmin,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				BlogPostId = current.BlogPostId,
				Comment = current.Comment,
				InsertDateTime = current.InsertDateTime,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogCommentGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogCommentGetResponseDto>>();

		var blogComments = await databaseContext.BlogComment
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogComments
			.Select(current => new BlogCommentGetResponseDto
			{
				Id = current.Id,
				FirstName = current.FirstName,
				LastName = current.LastName,
				ConfirmedByAdmin = current.ConfirmedByAdmin,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				BlogPostId = current.BlogPostId,
				Comment = current.Comment,
				InsertDateTime = current.InsertDateTime,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogCommentGetResponseDto>>> GetByBlogId(int blogPostId, int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogCommentGetResponseDto>>();

		var blogComments = await databaseContext.BlogComment
			.Where(current => current.BlogPostId == blogPostId)
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogComments
			.Select(current => new BlogCommentGetResponseDto
			{

				Id = current.Id,
				FirstName = current.FirstName,
				LastName = current.LastName,
				ConfirmedByAdmin = current.ConfirmedByAdmin,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				BlogPostId = current.BlogPostId,
				Comment = current.Comment,
				InsertDateTime = current.InsertDateTime,
			})
			.ToList();

		return serviceResult;
	}
}
