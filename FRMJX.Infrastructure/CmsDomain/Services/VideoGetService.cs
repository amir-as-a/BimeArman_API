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

internal class VideoGetService : IVideoGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public VideoGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<VideoGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<VideoGetResponseDto>();

		var video = await databaseContext.Videos
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (video != null)
		{
			serviceResult.Result = new VideoGetResponseDto
			{
				Id = video.Id,
				Ordering = video.Ordering,
				IsActive = video.IsActive,
				Title = video.Title,
				Description = video.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(video.CustomFileId, CustomFileType.Video, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<VideoGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<VideoGetResponseDto>>();

		var videos = await databaseContext.Videos
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = videos
			.Select(current => new VideoGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Video, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<VideoGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<VideoGetResponseDto>>();

		var videos = await databaseContext.Videos
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = videos
			.Select(current => new VideoGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Video, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
