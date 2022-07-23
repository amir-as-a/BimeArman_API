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

internal class AboutUsGetService : IAboutUsGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public AboutUsGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<AboutUsGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<AboutUsGetResponseDto>();

		var aboutUs = await databaseContext.AboutUses
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (aboutUs != null)
		{
			serviceResult.Result = new AboutUsGetResponseDto
			{
				Id = aboutUs.Id,
				Ordering = aboutUs.Ordering,
				IsActive = aboutUs.IsActive,
				Title = aboutUs.Title,
				Description = aboutUs.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(aboutUs.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<AboutUsGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<AboutUsGetResponseDto>>();

		var aboutUss = await databaseContext.AboutUses
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = aboutUss
			.Select(current => new AboutUsGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<AboutUsGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<AboutUsGetResponseDto>>();

		var aboutUss = await databaseContext.AboutUses
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = aboutUss
			.Select(current => new AboutUsGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
