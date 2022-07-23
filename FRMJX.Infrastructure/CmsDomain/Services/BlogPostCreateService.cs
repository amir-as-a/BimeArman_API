namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class BlogPostCreateService : IBlogPostCreateService
{
	private readonly DatabaseContext databaseContext;

	public BlogPostCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		BlogPostCreateAndUpdateRequestDto blogPostCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var blogPost = new BlogPost
		{
			CultureLcid = blogPostCreateAndUpdateDto.CultureLcid,
			IsActive = blogPostCreateAndUpdateDto.IsActive,
			Ordering = blogPostCreateAndUpdateDto.Ordering,
			Title = blogPostCreateAndUpdateDto.Title,
			Body = blogPostCreateAndUpdateDto.Body,
			InsertDateTime = DateTime.Now,
			PictureId = blogPostCreateAndUpdateDto.PictureId,
			BlogTypeId = blogPostCreateAndUpdateDto.BlogTypeId,
		};

		databaseContext.BlogPosts.Add(blogPost);
		await databaseContext.SaveChangesAsync(cancellationToken);

		blogPost.BlogPostBlogCategories = new List<BlogPostBlogCategory>();

		var category = databaseContext.BlogCategories.SingleOrDefault(m => m.Id == blogPostCreateAndUpdateDto.BlogCategoryId);
		if (category != null)
		{
			blogPost.BlogPostBlogCategories.Add(new BlogPostBlogCategory
			{
				BlogCategoryId = blogPostCreateAndUpdateDto.BlogCategoryId,
				BlogPostId = blogPost.Id,
			});
		}

		databaseContext.BlogPosts.Update(blogPost);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = blogPost.Id;

		return serviceResult;
	}
}
