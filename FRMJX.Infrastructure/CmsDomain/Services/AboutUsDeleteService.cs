namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class AboutUsDeleteService : IAboutUsDeleteService
{
	private readonly DatabaseContext databaseContext;

	public AboutUsDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var aboutUs = databaseContext.AboutUses
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (aboutUs is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(aboutUs);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
