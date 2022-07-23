namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SuggustionDeleteService : ISuggustionDeleteService
{
	private readonly DatabaseContext databaseContext;

	public SuggustionDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var suggustion = databaseContext.Suggustions
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (suggustion is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(suggustion);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
