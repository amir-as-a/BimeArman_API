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

internal class SliderItemGetService : ISliderItemGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public SliderItemGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<SliderItemGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<SliderItemGetResponseDto>();

		var sliderItem = await databaseContext.SliderItems
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (sliderItem != null)
		{
			serviceResult.Result = new SliderItemGetResponseDto
			{
				Id = sliderItem.Id,
				Ordering = sliderItem.Ordering,
				IsActive = sliderItem.IsActive,
				Title = sliderItem.Title,
				Description = sliderItem.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(sliderItem.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<SliderItemGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SliderItemGetResponseDto>>();

		var sliderItems = await databaseContext.SliderItems
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = sliderItems
			.Select(current => new SliderItemGetResponseDto
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

	public async Task<ServiceResult<List<SliderItemGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SliderItemGetResponseDto>>();

		var sliderItems = await databaseContext.SliderItems
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = sliderItems
			.Select(current => new SliderItemGetResponseDto
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

	public async Task<ServiceResult<List<SliderItemGetResponseDto>>> GetAboutUsSlider(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SliderItemGetResponseDto>>();

		var sliderItems = await databaseContext.SliderItems
			.Where(current => current.CultureLcid == cultureLcid && current.AboutUsSlider == true)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = sliderItems
			.Select(current => new SliderItemGetResponseDto
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
