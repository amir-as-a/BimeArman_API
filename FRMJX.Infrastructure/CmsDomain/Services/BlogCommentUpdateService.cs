namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class BlogCommentUpdateService : IBlogCommentUpdateService
{
	private readonly DatabaseContext databaseContext;

	public BlogCommentUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		BlogCommentCreateAndUpdateRequestDto blogCommentCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogComment = await databaseContext.BlogComment
			.SingleOrDefaultAsync(current => current.Id == id);

		if (blogComment is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "BlogComment not found");
			return serviceResult;
		}

		blogComment.Comment = blogCommentCreateAndUpdateDto.Comment;
		blogComment.FirstName = blogCommentCreateAndUpdateDto.FirstName;
		blogComment.LastName = blogCommentCreateAndUpdateDto.LastName;
		blogComment.ConfirmedByAdmin = blogCommentCreateAndUpdateDto.ConfirmedByAdmin;
		blogComment.BlogPostId = blogCommentCreateAndUpdateDto.BlogPostId;
		blogComment.Ordering = blogCommentCreateAndUpdateDto.Ordering;
		blogComment.IsActive = blogCommentCreateAndUpdateDto.IsActive;
		blogComment.UpdateDateTime = DateTime.Now;

		databaseContext.Update(blogComment);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}

	public async Task<ServiceResult> ApprovalComment(
	int id,
	bool isApproval,
	CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogComment = await databaseContext.BlogComment
			.SingleOrDefaultAsync(current => current.Id == id);

		if (blogComment is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "BlogComment not found");
			return serviceResult;
		}

		blogComment.ConfirmedByAdmin = isApproval;
		blogComment.UpdateDateTime = DateTime.Now;

		databaseContext.Update(blogComment);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
