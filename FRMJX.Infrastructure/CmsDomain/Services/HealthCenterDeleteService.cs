namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class HealthCenterDeleteService : IHealthCenterDeleteService
{
	private readonly DatabaseContext databaseContext;

	public HealthCenterDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var healthCenter = databaseContext.HealthCenters
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (healthCenter is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(healthCenter);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
