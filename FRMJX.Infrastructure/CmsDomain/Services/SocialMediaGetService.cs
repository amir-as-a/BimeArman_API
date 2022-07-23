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

internal class SocialMediaGetService : ISocialMediaGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public SocialMediaGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<SocialMediaGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<SocialMediaGetResponseDto>();

		var socialMedia = await databaseContext.SocialMedia
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (socialMedia != null)
		{
			serviceResult.Result = new SocialMediaGetResponseDto
			{
				Id = socialMedia.Id,
				Ordering = socialMedia.Ordering,
				IsActive = socialMedia.IsActive,
				Title = socialMedia.Title,
				Url = socialMedia.Url,
				CustomFileGetResponseDto = customFileGetService.GetById(socialMedia.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<SocialMediaGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SocialMediaGetResponseDto>>();

		var socialMedias = await databaseContext.SocialMedia
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = socialMedias
			.Select(current => new SocialMediaGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Url = current.Url,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<SocialMediaGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SocialMediaGetResponseDto>>();

		var socialMedias = await databaseContext.SocialMedia
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = socialMedias
			.Select(current => new SocialMediaGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Url = current.Url,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
