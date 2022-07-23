namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class BlogPostDeleteService : IBlogPostDeleteService
{
	private readonly DatabaseContext databaseContext;

	public BlogPostDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogPost = databaseContext.BlogPosts
			.Where(current => current.Id == id)
			.Include(current => current.BlogPostBlogCategories)
			.SingleOrDefault();

		if (blogPost is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(blogPost);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
