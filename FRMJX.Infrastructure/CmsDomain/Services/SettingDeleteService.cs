namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SettingDeleteService : ISettingDeleteService
{
	private readonly DatabaseContext databaseContext;

	public SettingDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var setting = databaseContext.Settings
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (setting is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(setting);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
