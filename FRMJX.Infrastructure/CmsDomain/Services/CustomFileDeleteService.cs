namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class CustomFileDeleteService : ICustomFileDeleteService
{
	private readonly DatabaseContext databaseContext;

	public CustomFileDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var customFile = databaseContext.CustomFiles
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (customFile is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(customFile);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
