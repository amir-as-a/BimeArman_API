namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class VideoCreateService : IVideoCreateService
{
	private readonly DatabaseContext databaseContext;

	public VideoCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		VideoCreateAndUpdateRequestDto videoCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var video = new Video
		{
			CultureLcid = videoCreateAndUpdateDto.CultureLcid,
			IsActive = videoCreateAndUpdateDto.IsActive,
			Ordering = videoCreateAndUpdateDto.Ordering,
			Title = videoCreateAndUpdateDto.Title,
			Description = videoCreateAndUpdateDto.Description,
			CustomFileId = videoCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Videos.Add(video);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = video.Id;

		return serviceResult;
	}
}
