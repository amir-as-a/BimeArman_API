namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class CustomFileCreateService : ICustomFileCreateService
{
	private readonly DatabaseContext databaseContext;

	public CustomFileCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		CustomFileCreateAndUpdateRequestDto customFileCreateAndUpdateRequestDto,
		CustomFileType customFileType,
		CancellationToken cancellationToken)
	{
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
			var fileName = Path.GetFileName(customFileCreateAndUpdateRequestDto.FormFile.FileName);
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + folderName, fileName);
			var nextFilePath = Utility.GetNextFilename(filePath);
			finalFileName = Path.GetFileName(nextFilePath);
			using (var fileStream = new FileStream(nextFilePath, FileMode.Create))
			{
				customFileCreateAndUpdateRequestDto.FormFile.CopyTo(fileStream);
			}
		}

		var serviceResult = new ServiceResult<int>();

		using var memoryStream = new MemoryStream();
		customFileCreateAndUpdateRequestDto.FormFile.CopyTo(memoryStream);
		var fileContent = memoryStream.ToArray();

		var customFile = new CustomFile
		{
			Content = fileContent,
			ContentType = customFileCreateAndUpdateRequestDto.FormFile.ContentType,
			Name = finalFileName,
			Size = customFileCreateAndUpdateRequestDto.FormFile.Length,
		};

		databaseContext.CustomFiles.Add(customFile);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = customFile.Id;

		return serviceResult;
	}
}
