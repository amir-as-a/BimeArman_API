namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class CustomFileUpdateService : ICustomFileUpdateService
{
	private readonly DatabaseContext databaseContext;

	public CustomFileUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto,
		CustomFileType customFileType,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var customFile = await databaseContext.CustomFiles
			.SingleOrDefaultAsync(current => current.Id == id);

		if (customFile is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "CustomFile not found");
			return serviceResult;
		}

		string finalFileName = string.Empty;
		string folderName = customFileType switch
		{
			CustomFileType.Image => "images",
			CustomFileType.Video => "videos",
			CustomFileType.File => "files",
			_ => "images",
		};

		if (customFileCreateAndUpdateRequestDto.FormFile != null && customFileCreateAndUpdateRequestDto.FormFile.Length > 0)
		{
			var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + folderName, customFile.Name);
			if (File.Exists(oldFilePath))
			{
				File.Delete(oldFilePath);
			}

			var fileName = Path.GetFileName(customFileCreateAndUpdateRequestDto.FormFile.FileName);
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + folderName, fileName);
			var nextFilePath = Utility.GetNextFilename(filePath);
			finalFileName = Path.GetFileName(nextFilePath);
			using (var fileStream = new FileStream(nextFilePath, FileMode.Create))
			{
				customFileCreateAndUpdateRequestDto.FormFile.CopyTo(fileStream);
			}
		}

		using var memoryStream = new MemoryStream();
		customFileCreateAndUpdateRequestDto.FormFile.CopyTo(memoryStream);
		var fileContent = memoryStream.ToArray();

		customFile.Content = fileContent;
		customFile.ContentType = customFileCreateAndUpdateRequestDto.FormFile.ContentType;
		customFile.Name = finalFileName;
		customFile.Size = customFileCreateAndUpdateRequestDto.FormFile.Length;

		databaseContext.Update(customFile);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
