namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class AboutUsAttributeDeleteService : IAboutUsAttributeDeleteService
{
	private readonly DatabaseContext databaseContext;

	public AboutUsAttributeDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var aboutUsAttribute = databaseContext.AboutUsAttributes
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (aboutUsAttribute is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(aboutUsAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
