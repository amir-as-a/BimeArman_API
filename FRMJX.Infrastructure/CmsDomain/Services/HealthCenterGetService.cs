namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class HealthCenterGetService : IHealthCenterGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICityGetService cityGetService;

	public HealthCenterGetService(DatabaseContext databaseContext,
		ICityGetService cityGetService)
	{
		this.databaseContext = databaseContext;
		this.cityGetService = cityGetService;
	}

	public async Task<ServiceResult<HealthCenterGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<HealthCenterGetResponseDto>();

		var healthCenter = await databaseContext.HealthCenters
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (healthCenter != null)
		{
			serviceResult.Result = new HealthCenterGetResponseDto
			{
				Id = healthCenter.Id,
				Ordering = healthCenter.Ordering,
				IsActive = healthCenter.IsActive,
				Center = healthCenter.Center,
				CenterName = healthCenter.CenterName,
				PhoneNumber = healthCenter.PhoneNumber,
				ExactAddress = healthCenter.ExactAddress,
				CityId = healthCenter.CityId,
				CityGetResponseDto = cityGetService.GetById(healthCenter.CityId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<HealthCenterGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<HealthCenterGetResponseDto>>();
		var r = databaseContext.HealthCenters.ToList();
		var healthCenters = await databaseContext.HealthCenters
			.Where(current => current.CultureLcid == cultureLcid && current.IsActive == true)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = healthCenters
			.Select(current => new HealthCenterGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Center = current.Center,
				CenterName = current.CenterName,
				PhoneNumber = current.PhoneNumber,
				ExactAddress = current.ExactAddress,
				CityId = current.CityId,
				CityGetResponseDto = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<HealthCenterGetResponseDto>>> GetAll(int cultureLcid, int? stateId, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<HealthCenterGetResponseDto>>();

		var query = databaseContext.HealthCenters
			.Where(current => current.CultureLcid == cultureLcid)
			;

		if (stateId != null)
		{
			query = query.Include(x => x.City).Where(x => x.City.StateId == stateId);
		}

		var helthCenters = await query.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = helthCenters
			.Select(current => new HealthCenterGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Center = current.Center,
				CenterName = current.CenterName,
				PhoneNumber = current.PhoneNumber,
				CityId = current.CityId,
				ExactAddress = current.ExactAddress,
				CityGetResponseDto = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<HealthCenterGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<HealthCenterGetResponseDto>>();

		var healthCenters = await databaseContext.HealthCenters
			.Where(current => current.City.StateId == stateId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = healthCenters
			.Select(current => new HealthCenterGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Center = current.Center,
				CenterName = current.CenterName,
				PhoneNumber = current.PhoneNumber,
				ExactAddress = current.ExactAddress,
				CityId = current.CityId,
				CityGetResponseDto = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
