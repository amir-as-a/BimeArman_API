namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class GeneralRuleDeleteService : IGeneralRuleDeleteService
{
	private readonly DatabaseContext databaseContext;

	public GeneralRuleDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var generalRule = databaseContext.GeneralRule
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (generalRule is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(generalRule);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
