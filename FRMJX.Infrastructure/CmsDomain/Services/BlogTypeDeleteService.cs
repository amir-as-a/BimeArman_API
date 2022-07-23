namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class BlogTypeDeleteService : IBlogTypeDeleteService
{
	private readonly DatabaseContext databaseContext;

	public BlogTypeDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogType = databaseContext.BlogTypes
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (blogType is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(blogType);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
