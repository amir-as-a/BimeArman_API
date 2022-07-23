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

internal class GeneralConditionGetService : IGeneralConditionGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public GeneralConditionGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<GeneralConditionGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<GeneralConditionGetResponseDto>();

		var generalCondition = await databaseContext.GeneralCondition
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (generalCondition != null)
		{
			serviceResult.Result = new GeneralConditionGetResponseDto
			{
				Id = generalCondition.Id,
				Ordering = generalCondition.Ordering,
				IsActive = generalCondition.IsActive,
				Title = generalCondition.Title,
				Description = generalCondition.Description,

			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<GeneralConditionGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<GeneralConditionGetResponseDto>>();

		var generalConditions = await databaseContext.GeneralCondition
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = generalConditions
			.Select(current => new GeneralConditionGetResponseDto
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

	public async Task<ServiceResult<List<GeneralConditionGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<GeneralConditionGetResponseDto>>();

		var generalConditions = await databaseContext.GeneralCondition
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = generalConditions
			.Select(current => new GeneralConditionGetResponseDto
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
