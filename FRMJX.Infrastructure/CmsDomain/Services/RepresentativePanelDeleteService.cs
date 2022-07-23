namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RepresentativePanelDeleteService : IRepresentativePanelDeleteService
{
	private readonly DatabaseContext databaseContext;

	public RepresentativePanelDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var representativePanel = databaseContext.RepresentativePanels
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (representativePanel is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(representativePanel);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
