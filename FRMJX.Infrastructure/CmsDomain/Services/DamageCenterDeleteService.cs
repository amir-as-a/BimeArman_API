namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class DamageCenterDeleteService : IDamageCenterDeleteService
{
	private readonly DatabaseContext databaseContext;

	public DamageCenterDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var damageCenter = databaseContext.DamageCenters
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (damageCenter is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(damageCenter);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
