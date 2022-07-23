namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class ConditionMembershipDeleteService : IConditionMembershipDeleteService
{
	private readonly DatabaseContext databaseContext;

	public ConditionMembershipDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var conditionMembership = databaseContext.ConditionMembership
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (conditionMembership is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(conditionMembership);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
