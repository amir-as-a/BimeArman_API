namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class CustomFileGetService : ICustomFileGetService
{
	private readonly DatabaseContext databaseContext;

	public CustomFileGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<CustomFileGetResponseDto>>
		GetById(int id, CustomFileType customFileType, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<CustomFileGetResponseDto>();

		string folderName = customFileType switch
		{
			CustomFileType.Image => "images",
			CustomFileType.Video => "videos",
			CustomFileType.File => "files",
			_ => "images",
		};

		var customFile = await databaseContext.CustomFiles
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (customFile != null)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + folderName, customFile.Name);
			if (File.Exists(filePath) == false)
			{
				File.WriteAllBytes(filePath, customFile.Content);
			}

			serviceResult.Result = new CustomFileGetResponseDto
			{
				Id = customFile.Id,
				Url = $"{folderName}/{customFile.Name}",
			};
		}

		return serviceResult;
	}

	public CustomFile GetModelById(int id, CustomFileType customFileType, CancellationToken cancellationToken)
	{
		string folderName = customFileType switch
		{
			CustomFileType.Image => "images",
			CustomFileType.Video => "videos",
			CustomFileType.File => "files",
			_ => "images",
		};

		var customFile = databaseContext.CustomFiles
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (customFile != null)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + folderName, customFile.Name);
			if (File.Exists(filePath) == false)
			{
				File.WriteAllBytes(filePath, customFile.Content);
			}
		}

		return customFile;
	}
}
