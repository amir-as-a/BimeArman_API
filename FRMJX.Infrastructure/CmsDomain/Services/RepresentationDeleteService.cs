namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RepresentationDeleteService : IRepresentationDeleteService
{
	private readonly DatabaseContext databaseContext;

	public RepresentationDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var representation = databaseContext.Representations
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (representation is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(representation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
