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

internal class JobPositionGetService : IJobPositionGetService
{
	private readonly DatabaseContext databaseContext;

	public JobPositionGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<JobPositionGetResponseDto>> GetById(int? id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<JobPositionGetResponseDto>();

		var jobPosition = await databaseContext.JobPositions
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (jobPosition != null)
		{
			serviceResult.Result = new JobPositionGetResponseDto
			{
				Id = jobPosition.Id,
				Ordering = jobPosition.Ordering,
				IsActive = jobPosition.IsActive,
				Title = jobPosition.Title,
				Category = jobPosition.Category,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<JobPositionGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<JobPositionGetResponseDto>>();

		var jobPositions = await databaseContext.JobPositions
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = jobPositions
			.Select(current => new JobPositionGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Category = current.Category,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<JobPositionGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<JobPositionGetResponseDto>>();

		var jobPositions = await databaseContext.JobPositions
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = jobPositions
			.Select(current => new JobPositionGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Category = current.Category,
			})
			.ToList();

		return serviceResult;
	}
}
