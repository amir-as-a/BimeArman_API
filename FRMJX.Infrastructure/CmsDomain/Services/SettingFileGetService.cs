namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class SettingFileGetService : ISettingFileGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public SettingFileGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<SettingFileGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<SettingFileGetResponseDto>();

		var setting = await databaseContext.SettingFiles
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (setting != null)
		{
			serviceResult.Result = new SettingFileGetResponseDto
			{
				Id = setting.Id,
				CustomFileGetResponseDto = customFileGetService.GetById(setting.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				Name = setting.Name,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<SettingFileGetResponseDto>>> GetByNames(int cultureLcid, string[] names, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SettingFileGetResponseDto>>();

		names = names.Select(d => d.ToLower()).ToArray();

		var settings = await databaseContext.SettingFiles
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => names.Contains(current.Name.ToLower()))
			.ToListAsync(cancellationToken);

		serviceResult.Result = settings
			.Select(current => new SettingFileGetResponseDto
			{
				Id = current.Id,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<SettingFileGetResponseDto>>> Search(int cultureLcid, string q, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SettingFileGetResponseDto>>();

		var settings = await databaseContext.SettingFiles
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.Name.ToLower().Contains(q.ToLower()))
			.ToListAsync(cancellationToken);

		serviceResult.Result = settings
			.Select(current => new SettingFileGetResponseDto
			{
				Id = current.Id,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<SettingFileGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SettingFileGetResponseDto>>();

		var settings = await databaseContext.SettingFiles
			.Where(current => current.CultureLcid == cultureLcid)
			.ToListAsync(cancellationToken);

		serviceResult.Result = settings
			.Select(current => new SettingFileGetResponseDto
			{
				Id = current.Id,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}
}
