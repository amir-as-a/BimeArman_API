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

internal class PersonnelPanelGetService : IPersonnelPanelGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;
	private readonly IPersonnelPanelCategoryGetService personnelPanelCategoryGetService;

	public PersonnelPanelGetService(DatabaseContext databaseContext,
		ICustomFileGetService customFileGetService,
		IPersonnelPanelCategoryGetService personnelPanelCategoryGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
		this.personnelPanelCategoryGetService = personnelPanelCategoryGetService;
	}

	public async Task<ServiceResult<PersonnelPanelGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<PersonnelPanelGetResponseDto>();

		var personnelPanel = await databaseContext.PersonnelPanels
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (personnelPanel != null)
		{
			serviceResult.Result = new PersonnelPanelGetResponseDto
			{
				Id = personnelPanel.Id,
				Description = personnelPanel.Description,
				Title = personnelPanel.Title,
				Ordering = personnelPanel.Ordering,
				IsActive = personnelPanel.IsActive,
				InsertTime = personnelPanel.InsertDateTime,
				CustomFileGetResponseDto = customFileGetService.GetById(personnelPanel.CustomFileId , CustomFileType.File,cancellationToken).Result.Result,
				PersonnelPanelCategoryGetResponse = personnelPanelCategoryGetService.GetById(personnelPanel.PanelCategoryId,cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<PersonnelPanelGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<PersonnelPanelGetResponseDto>>();

		var personnelPanels = await databaseContext.PersonnelPanels
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = personnelPanels
			.Select(current => new PersonnelPanelGetResponseDto
			{
				Id = current.Id,
				Title = current.Title,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Description = current.Description,
				InsertTime = current.InsertDateTime,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId,CustomFileType.File,cancellationToken).Result.Result,
				PersonnelPanelCategoryGetResponse = personnelPanelCategoryGetService.GetById(current.PanelCategoryId,cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<PersonnelPanelGetResponseDto>>> GetByCategoryId(int categoryId, int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<PersonnelPanelGetResponseDto>>();

		var personnelPanels = await databaseContext.PersonnelPanels
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.PanelCategoryId == categoryId)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = personnelPanels
			.Select(current => new PersonnelPanelGetResponseDto
			{
				Id = current.Id,
				Title = current.Title,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Description = current.Description,
				InsertTime = current.InsertDateTime,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				PersonnelPanelCategoryGetResponse = personnelPanelCategoryGetService.GetById(current.PanelCategoryId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<PersonnelPanelGetResponseDto>>> GetAll(int cultureLcid, int? categoryId, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<PersonnelPanelGetResponseDto>>();

		var query =  databaseContext.PersonnelPanels
			.Where(current => current.CultureLcid == cultureLcid);

		if (categoryId != null)
		{
			query = query.Where(x => x.PanelCategoryId == categoryId);
		}

		var personnelPanels = await query
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = personnelPanels
			.Select(current => new PersonnelPanelGetResponseDto
			{
				Id = current.Id,
				Title = current.Title,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Description = current.Description,
				InsertTime = current.InsertDateTime,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				PersonnelPanelCategoryGetResponse = personnelPanelCategoryGetService.GetById(current.PanelCategoryId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
