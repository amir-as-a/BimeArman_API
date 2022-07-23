namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using FRMJX.Infrastructure.BasicDataDomain.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class DamageCenterGetService : IDamageCenterGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IStateGetService stateGetService;
	private readonly ICityGetService cityGetService;

	public DamageCenterGetService(DatabaseContext databaseContext, IStateGetService stateGetService, ICityGetService cityGetService)
	{
		this.databaseContext = databaseContext;
		this.stateGetService = stateGetService;
		this.cityGetService = cityGetService;
	}

	public async Task<ServiceResult<DamageCenterGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<DamageCenterGetResponseDto>();

		var damageCenter = await databaseContext.DamageCenters
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (damageCenter != null)
		{
			serviceResult.Result = new DamageCenterGetResponseDto
			{
				Id = damageCenter.Id,
				Ordering = damageCenter.Ordering,
				IsActive = damageCenter.IsActive,
				ExactAddress = damageCenter.ExactAddress,
				BranchManager = damageCenter.BranchManager,
				BranchName = damageCenter.BranchName,
				PhoneNumber = damageCenter.PhoneNumber,
				PostalCode = damageCenter.PostalCode,
				CityId = damageCenter.CityId,
				StateId = damageCenter.StateId,
				StateInfo = stateGetService.GetById(damageCenter.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(damageCenter.CityId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<DamageCenterGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<DamageCenterGetResponseDto>>();

		var damageCenters = await databaseContext.DamageCenters
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = damageCenters
			.Select(current => new DamageCenterGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ExactAddress = current.ExactAddress,
				BranchManager = current.BranchManager,
				BranchName = current.BranchName,
				PhoneNumber = current.PhoneNumber,
				PostalCode = current.PostalCode,
				StateId = current.StateId,
				CityId = current.CityId,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<DamageCenterGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<DamageCenterGetResponseDto>>();

		var damageCenters = await databaseContext.DamageCenters
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = damageCenters
			.Select(current => new DamageCenterGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ExactAddress = current.ExactAddress,
				BranchManager = current.BranchManager,
				BranchName = current.BranchName,
				PhoneNumber = current.PhoneNumber,
				PostalCode = current.PostalCode,
				StateId = current.StateId,
				CityId = current.CityId,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<DamageCenterGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<DamageCenterGetResponseDto>>();

		var damageCenters = await databaseContext.DamageCenters
			.Where(current => current.StateId == stateId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = damageCenters
			.Select(current => new DamageCenterGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ExactAddress = current.ExactAddress,
				BranchManager = current.BranchManager,
				BranchName = current.BranchName,
				PhoneNumber = current.PhoneNumber,
				PostalCode = current.PostalCode,
				StateId = current.StateId,
				CityId = current.CityId,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<DamageCenterGetResponseDto>>> GetByCity(int cityId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<DamageCenterGetResponseDto>>();

		var damageCenters = await databaseContext.DamageCenters
			.Where(current => current.CityId == cityId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = damageCenters
			.Select(current => new DamageCenterGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ExactAddress = current.ExactAddress,
				BranchManager = current.BranchManager,
				BranchName = current.BranchName,
				PhoneNumber = current.PhoneNumber,
				PostalCode = current.PostalCode,
				StateId = current.StateId,
				CityId = current.CityId,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
