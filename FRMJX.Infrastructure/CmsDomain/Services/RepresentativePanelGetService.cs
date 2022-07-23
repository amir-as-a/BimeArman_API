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

internal class RepresentativePanelGetService : IRepresentativePanelGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;
	private readonly IRepresentativePanelCategoryGetService representativePanelCategoryGetService;

	public RepresentativePanelGetService(DatabaseContext databaseContext,
		ICustomFileGetService customFileGetService,
		IRepresentativePanelCategoryGetService representativePanelCategoryGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
		this.representativePanelCategoryGetService = representativePanelCategoryGetService;
	}

	public async Task<ServiceResult<RepresentativePanelGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<RepresentativePanelGetResponseDto>();

		var representativePanel = await databaseContext.RepresentativePanels
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (representativePanel != null)
		{
			serviceResult.Result = new RepresentativePanelGetResponseDto
			{
				Id = representativePanel.Id,
				Description = representativePanel.Description,
				Title = representativePanel.Title,
				Ordering = representativePanel.Ordering,
				IsActive = representativePanel.IsActive,
				InsertTime = representativePanel.InsertDateTime,
				CustomFileGetResponseDto = customFileGetService.GetById(representativePanel.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				RepresentativePanelCategoryGetResponse = representativePanelCategoryGetService.GetById(representativePanel.PanelCategoryId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<RepresentativePanelGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentativePanelGetResponseDto>>();

		var representativePanels = await databaseContext.RepresentativePanels
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representativePanels
			.Select(current => new RepresentativePanelGetResponseDto
			{
				Id = current.Id,
				Title = current.Title,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Description = current.Description,
				InsertTime = current.InsertDateTime,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				RepresentativePanelCategoryGetResponse = representativePanelCategoryGetService.GetById(current.PanelCategoryId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<RepresentativePanelGetResponseDto>>> GetByCategoryId(int categoryId, int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentativePanelGetResponseDto>>();

		var representativePanels = await databaseContext.RepresentativePanels
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.PanelCategoryId == categoryId)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representativePanels
			.Select(current => new RepresentativePanelGetResponseDto
			{
				Id = current.Id,
				Title = current.Title,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Description = current.Description,
				InsertTime = current.InsertDateTime,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				RepresentativePanelCategoryGetResponse = representativePanelCategoryGetService.GetById(current.PanelCategoryId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<RepresentativePanelGetResponseDto>>> GetAll(int cultureLcid, int? categoryId, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentativePanelGetResponseDto>>();

		var query = databaseContext.RepresentativePanels
			.Where(current => current.CultureLcid == cultureLcid);

		if (categoryId != null)
		{
			query = query.Where(x => x.PanelCategoryId == categoryId);
		}

		var representativePanels = await query
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representativePanels
			.Select(current => new RepresentativePanelGetResponseDto
			{
				Id = current.Id,
				Title = current.Title,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Description = current.Description,
				InsertTime = current.InsertDateTime,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				RepresentativePanelCategoryGetResponse = representativePanelCategoryGetService.GetById(current.PanelCategoryId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
