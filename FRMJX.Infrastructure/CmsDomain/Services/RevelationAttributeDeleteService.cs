namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RevelationAttributeDeleteService : IRevelationAttributeDeleteService
{
	private readonly DatabaseContext databaseContext;

	public RevelationAttributeDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var revelationAttribute = databaseContext.RevelationAttributes
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (revelationAttribute is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(revelationAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
