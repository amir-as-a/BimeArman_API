namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SettingFileDeleteService : ISettingFileDeleteService
{
	private readonly DatabaseContext databaseContext;

	public SettingFileDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var settingFile = databaseContext.SettingFiles
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (settingFile is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(settingFile);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
