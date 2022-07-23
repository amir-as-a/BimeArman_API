namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class GeneralConditionDeleteService : IGeneralConditionDeleteService
{
	private readonly DatabaseContext databaseContext;

	public GeneralConditionDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var generalCondition = databaseContext.GeneralCondition
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (generalCondition is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(generalCondition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
