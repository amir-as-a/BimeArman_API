namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class PersonnelPanelCategoryGetService : IPersonnelPanelCategoryGetService
{
	private readonly DatabaseContext databaseContext;

	public PersonnelPanelCategoryGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<PersonnelPanelCategoryGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<PersonnelPanelCategoryGetResponseDto>();

		var personnelPanelCategory = await databaseContext.PersonnelPanelCategories
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (personnelPanelCategory != null)
		{
			serviceResult.Result = new PersonnelPanelCategoryGetResponseDto
			{
				Id = personnelPanelCategory.Id,
				Ordering = personnelPanelCategory.Ordering,
				IsActive = personnelPanelCategory.IsActive,
				Title = personnelPanelCategory.Title,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<PersonnelPanelCategoryGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<PersonnelPanelCategoryGetResponseDto>>();

		var personnelPanelCategorys = await databaseContext.PersonnelPanelCategories
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = personnelPanelCategorys
			.Select(current => new PersonnelPanelCategoryGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<PersonnelPanelCategoryGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<PersonnelPanelCategoryGetResponseDto>>();

		var personnelPanelCategorys = await databaseContext.PersonnelPanelCategories
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = personnelPanelCategorys
			.Select(current => new PersonnelPanelCategoryGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
			})
			.ToList();

		return serviceResult;
	}
}
