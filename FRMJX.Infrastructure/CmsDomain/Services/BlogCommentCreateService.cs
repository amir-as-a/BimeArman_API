namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class BlogCommentCreateService : IBlogCommentCreateService
{
	private readonly DatabaseContext databaseContext;

	public BlogCommentCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		BlogCommentCreateAndUpdateRequestDto blogCommentCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var blogComment = new BlogComment
		{
			CultureLcid = blogCommentCreateAndUpdateDto.CultureLcid,
			IsActive = blogCommentCreateAndUpdateDto.IsActive,
			Ordering = blogCommentCreateAndUpdateDto.Ordering,
			FirstName = blogCommentCreateAndUpdateDto.FirstName,
			LastName = blogCommentCreateAndUpdateDto.LastName,
			ConfirmedByAdmin = false,
			Comment = blogCommentCreateAndUpdateDto.Comment,
			BlogPostId = blogCommentCreateAndUpdateDto.BlogPostId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.BlogComment.Add(blogComment);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = blogComment.Id;

		return serviceResult;
	}
}
