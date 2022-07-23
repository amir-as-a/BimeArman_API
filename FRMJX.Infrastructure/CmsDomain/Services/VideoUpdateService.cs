namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class VideoUpdateService : IVideoUpdateService
{
	private readonly DatabaseContext databaseContext;

	public VideoUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		VideoCreateAndUpdateRequestDto videoCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var video = await databaseContext.Videos
			.SingleOrDefaultAsync(current => current.Id == id);

		if (video is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Video not found");
			return serviceResult;
		}

		video.Title = videoCreateAndUpdateDto.Title;
		video.Description = videoCreateAndUpdateDto.Description;
		video.CustomFileId = videoCreateAndUpdateDto.CustomFileId;
		video.Ordering = videoCreateAndUpdateDto.Ordering;
		video.IsActive = videoCreateAndUpdateDto.IsActive;
		video.UpdateDateTime = DateTime.Now;

		databaseContext.Update(video);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
