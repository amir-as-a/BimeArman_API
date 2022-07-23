namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RepresentationConditionDeleteService : IRepresentationConditionDeleteService
{
	private readonly DatabaseContext databaseContext;

	public RepresentationConditionDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var representationCondition = databaseContext.RepresentationConditions
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (representationCondition is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(representationCondition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
