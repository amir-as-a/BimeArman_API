namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RegulationDeleteService : IRegulationDeleteService
{
	private readonly DatabaseContext databaseContext;

	public RegulationDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var regulation = databaseContext.Regulations
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (regulation is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(regulation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
