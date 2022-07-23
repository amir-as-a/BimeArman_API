namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class SettingCreateService : ISettingCreateService
{
	private readonly DatabaseContext databaseContext;

	public SettingCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		SettingCreateAndUpdateRequestDto settingCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var exist = databaseContext.Settings
			.Where(m => m.CultureLcid == settingCreateAndUpdateDto.CultureLcid)
			.Where(m => m.Name.ToLower() == settingCreateAndUpdateDto.Name.ToLower())
			.SingleOrDefault();

		if (exist != null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.BadRequest, "Setting name must be unique");
			return serviceResult;
		}

		var setting = new Setting
		{
			CultureLcid = settingCreateAndUpdateDto.CultureLcid,
			Name = settingCreateAndUpdateDto.Name,
			Value = settingCreateAndUpdateDto.Value,
		};

		databaseContext.Settings.Add(setting);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = setting.Id;

		return serviceResult;
	}
}
