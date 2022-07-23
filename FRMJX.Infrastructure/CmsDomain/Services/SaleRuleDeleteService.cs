namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SaleRuleDeleteService : ISaleRuleDeleteService
{
	private readonly DatabaseContext databaseContext;

	public SaleRuleDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var saleRule = databaseContext.SaleRules
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (saleRule is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(saleRule);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
