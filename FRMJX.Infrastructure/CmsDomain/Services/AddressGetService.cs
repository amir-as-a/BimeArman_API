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

internal class AddressGetService : IAddressGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IStateGetService stateGetService;
	private readonly ICityGetService cityGetService;

	public AddressGetService(DatabaseContext databaseContext, IStateGetService stateGetService, ICityGetService cityGetService)
	{
		this.databaseContext = databaseContext;
		this.stateGetService = stateGetService;
		this.cityGetService = cityGetService;
	}

	public async Task<ServiceResult<AddressGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<AddressGetResponseDto>();

		var addresses = await databaseContext.Addresses
			.Where(current => current.Id == id)
			.OrderBy(current => current.Ordering)
			.SingleOrDefaultAsync(cancellationToken);

		if (addresses != null)
		{
			serviceResult.Result = new AddressGetResponseDto
			{
				Id = addresses.Id,
				Ordering = addresses.Ordering,
				IsActive = addresses.IsActive,
				ExactAddress = addresses.ExactAddress,
				CityId = addresses.CityId,
				StateId = addresses.StateId,
				StateInfo = stateGetService.GetById(addresses.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(addresses.CityId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<AddressGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<AddressGetResponseDto>>();

		var addresss = await databaseContext.Addresses
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = addresss
			.Select(current => new AddressGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ExactAddress = current.ExactAddress,
				CityId = current.CityId,
				StateId = current.StateId,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<AddressGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<AddressGetResponseDto>>();

		var addresss = await databaseContext.Addresses
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = addresss
			.Select(current => new AddressGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ExactAddress = current.ExactAddress,
				CityId = current.CityId,
				StateId = current.StateId,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<AddressGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<AddressGetResponseDto>>();

		var addresss = await databaseContext.Addresses
			.Where(current => current.StateId == stateId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = addresss
			.Select(current => new AddressGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ExactAddress = current.ExactAddress,
				CityId = current.CityId,
				StateId = current.StateId,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<AddressGetResponseDto>>> GetByCity(int cityId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<AddressGetResponseDto>>();

		var addresss = await databaseContext.Addresses
			.Where(current => current.CityId == cityId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = addresss
			.Select(current => new AddressGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ExactAddress = current.ExactAddress,
				CityId = current.CityId,
				StateId = current.StateId,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
