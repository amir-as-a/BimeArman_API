namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class VendoringDeleteService : IVendoringDeleteService
{
	private readonly DatabaseContext databaseContext;

	public VendoringDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var vendoring = databaseContext.Vendorings
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (vendoring is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(vendoring);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
