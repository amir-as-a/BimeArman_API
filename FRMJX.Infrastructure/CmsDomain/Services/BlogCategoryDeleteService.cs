namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class BlogCategoryDeleteService : IBlogCategoryDeleteService
{
	private readonly DatabaseContext databaseContext;

	public BlogCategoryDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogCategory = databaseContext.BlogCategories
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (blogCategory is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(blogCategory);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
