namespace FRMJX.Infrastructure.BasicDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class StateDeleteService : IStateDeleteService
{
	private readonly DatabaseContext databaseContext;

	public StateDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(long id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var state = databaseContext.States
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (state is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(state);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
