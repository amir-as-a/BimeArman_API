namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SettingUpdateService : ISettingUpdateService
{
	private readonly DatabaseContext databaseContext;

	public SettingUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		SettingCreateAndUpdateRequestDto settingCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var setting = await databaseContext.Settings
			.SingleOrDefaultAsync(current => current.Id == id);

		if (setting is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Setting not found");
			return serviceResult;
		}

		setting.Value = settingCreateAndUpdateDto.Value;

		databaseContext.Update(setting);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
