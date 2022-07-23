namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class JobPositionDeleteService : IJobPositionDeleteService
{
	private readonly DatabaseContext databaseContext;

	public JobPositionDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var jobPosition = databaseContext.JobPositions
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (jobPosition is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(jobPosition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
