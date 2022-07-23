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

internal class RepresentationConditionGetService : IRepresentationConditionGetService
{
	private readonly DatabaseContext databaseContext;

	public RepresentationConditionGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<RepresentationConditionGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<RepresentationConditionGetResponseDto>();

		var representationCondition = await databaseContext.RepresentationConditions
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (representationCondition != null)
		{
			serviceResult.Result = new RepresentationConditionGetResponseDto
			{
				Id = representationCondition.Id,
				Ordering = representationCondition.Ordering,
				IsActive = representationCondition.IsActive,
				Title = representationCondition.Title,
				Description = representationCondition.Description,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<RepresentationConditionGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentationConditionGetResponseDto>>();

		var representationConditions = await databaseContext.RepresentationConditions
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representationConditions
			.Select(current => new RepresentationConditionGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<RepresentationConditionGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentationConditionGetResponseDto>>();

		var representationConditions = await databaseContext.RepresentationConditions
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representationConditions
			.Select(current => new RepresentationConditionGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
			})
			.ToList();

		return serviceResult;
	}
}
