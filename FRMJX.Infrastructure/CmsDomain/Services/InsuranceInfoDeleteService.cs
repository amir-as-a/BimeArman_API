namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class InsuranceInfoDeleteService : IInsuranceInfoDeleteService
{
	private readonly DatabaseContext databaseContext;

	public InsuranceInfoDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var insuranceInfo = databaseContext.InsuranceInfos
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (insuranceInfo is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(insuranceInfo);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
