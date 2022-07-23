namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SettingFileUpdateService : ISettingFileUpdateService
{
	private readonly DatabaseContext databaseContext;

	public SettingFileUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		SettingFileCreateAndUpdateRequestDto settingFileCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var settingFile = await databaseContext.SettingFiles
			.SingleOrDefaultAsync(current => current.Id == id);

		if (settingFile is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "SettingFile not found");
			return serviceResult;
		}

		settingFile.Name = settingFileCreateAndUpdateDto.Name;
		settingFile.CustomFileId = settingFileCreateAndUpdateDto.CustomFileId;

		databaseContext.Update(settingFile);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
