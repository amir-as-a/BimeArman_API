namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class InsuranceDeleteService : IInsuranceDeleteService
{
	private readonly DatabaseContext databaseContext;

	public InsuranceDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var insurance = databaseContext.Insurances
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (insurance is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(insurance);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
