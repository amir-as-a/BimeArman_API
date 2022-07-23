namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class BlogPostUpdateService : IBlogPostUpdateService
{
	private readonly DatabaseContext databaseContext;

	public BlogPostUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		BlogPostCreateAndUpdateRequestDto blogPostCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogPost = await databaseContext.BlogPosts
			.Include(current => current.BlogPostBlogCategories)
			.ThenInclude(x => x.BlogCategory)
			.SingleOrDefaultAsync(current => current.Id == id);

		if (blogPost is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "BlogPost not found");
			return serviceResult;
		}

		blogPost.Title = blogPostCreateAndUpdateDto.Title;
		blogPost.Body = blogPostCreateAndUpdateDto.Body;
		blogPost.BlogTypeId = blogPostCreateAndUpdateDto.BlogTypeId;
		blogPost.Ordering = blogPostCreateAndUpdateDto.Ordering;
		blogPost.IsActive = blogPostCreateAndUpdateDto.IsActive;
		blogPost.PictureId = blogPostCreateAndUpdateDto.PictureId;
		blogPost.UpdateDateTime = DateTime.Now;

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


		databaseContext.Update(blogPost);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
