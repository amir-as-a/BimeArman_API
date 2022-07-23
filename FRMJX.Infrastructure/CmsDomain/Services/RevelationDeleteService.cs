namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RevelationDeleteService : IRevelationDeleteService
{
	private readonly DatabaseContext databaseContext;

	public RevelationDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var revelation = databaseContext.Revelations
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (revelation is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(revelation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
