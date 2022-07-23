namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class HealthCenterPdfDeleteService : IHealthCenterPdfDeleteService
{
	private readonly DatabaseContext databaseContext;

	public HealthCenterPdfDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var healthCenterPdf = databaseContext.HealthCenterPdfs
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (healthCenterPdf is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(healthCenterPdf);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
