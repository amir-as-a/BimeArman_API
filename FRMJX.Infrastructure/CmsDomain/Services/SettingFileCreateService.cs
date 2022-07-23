namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class SettingFileCreateService : ISettingFileCreateService
{
	private readonly DatabaseContext databaseContext;

	public SettingFileCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		SettingFileCreateAndUpdateRequestDto settingFileCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var settingFile = new SettingFile
		{
			CultureLcid = settingFileCreateAndUpdateDto.CultureLcid,
			Name = settingFileCreateAndUpdateDto.Name,
			CustomFileId = settingFileCreateAndUpdateDto.CustomFileId,
		};

		databaseContext.SettingFiles.Add(settingFile);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = settingFile.Id;

		return serviceResult;
	}
}
