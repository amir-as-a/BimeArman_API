namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class BlogCommentDeleteService : IBlogCommentDeleteService
{
	private readonly DatabaseContext databaseContext;

	public BlogCommentDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogComment = databaseContext.BlogComment
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (blogComment is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(blogComment);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
