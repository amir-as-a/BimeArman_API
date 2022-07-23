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

internal class RepresentativePanelCategoryGetService : IRepresentativePanelCategoryGetService
{
	private readonly DatabaseContext databaseContext;

	public RepresentativePanelCategoryGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<RepresentativePanelCategoryGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<RepresentativePanelCategoryGetResponseDto>();

		var representativePanelCategory = await databaseContext.RepresentativePanelCategories
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (representativePanelCategory != null)
		{
			serviceResult.Result = new RepresentativePanelCategoryGetResponseDto
			{
				Id = representativePanelCategory.Id,
				Ordering = representativePanelCategory.Ordering,
				IsActive = representativePanelCategory.IsActive,
				Title = representativePanelCategory.Title,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<RepresentativePanelCategoryGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentativePanelCategoryGetResponseDto>>();

		var representativePanelCategorys = await databaseContext.RepresentativePanelCategories
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representativePanelCategorys
			.Select(current => new RepresentativePanelCategoryGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<RepresentativePanelCategoryGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentativePanelCategoryGetResponseDto>>();

		var representativePanelCategorys = await databaseContext.RepresentativePanelCategories
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representativePanelCategorys
			.Select(current => new RepresentativePanelCategoryGetResponseDto
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
