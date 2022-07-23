namespace FRMJX.Infrastructure.BasicDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;
using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class CityGetService : ICityGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IStateGetService stateGetService;

	public CityGetService(DatabaseContext databaseContext,
		IStateGetService stateGetService)
	{
		this.databaseContext = databaseContext;
		this.stateGetService = stateGetService;
	}

	public async Task<ServiceResult<CityGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<CityGetResponseDto>();

		var city = await databaseContext.City
			.Where(x => x.Id == id)
			.Include(x => x.State)
			.SingleOrDefaultAsync(cancellationToken);

		if (city != null)
		{
			serviceResult.Result = new CityGetResponseDto
			{
				Id = city.Id,
				Name = city.Name,
				Description = city.Description,
				StateInfo = new StateGetResponseDto
				{
					Id = city.State.Id,
					Name = city.State.Name,
					Description = city.State.Description,
				},
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<CityGetResponseDto>>> GetByStateId(int stateId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<CityGetResponseDto>>();

		var cities = await databaseContext.City
			.Where(x => x.StateId == stateId)
			.Include(x => x.State)
			.ToListAsync(cancellationToken);

		serviceResult.Result = cities
			.Select(current => new CityGetResponseDto
			{
				Id = current.Id,
				Name = current.Name,
				Description = current.Description,
				StateInfo = new StateGetResponseDto
				{
					Id = current.State.Id,
					Name = current.State.Name,
					Description = current.State.Description,
				},
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<CityGetResponseDto>>> GetActives(CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<CityGetResponseDto>>();

		var cities = await databaseContext.City
			.Include(x => x.State)
			.ToListAsync(cancellationToken);

		serviceResult.Result = cities
			.Select(current => new CityGetResponseDto
			{
				Id = current.Id,
				Name = current.Name,
				Description = current.Description,
				StateInfo = new StateGetResponseDto
				{
					Id = current.State.Id,
					Name = current.State.Name,
					Description = current.State.Description,
				},
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<CityGetResponseDto>>> GetAll(CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<CityGetResponseDto>>();

		var cities = await databaseContext.City
			.Include(x => x.State)
			.ToListAsync(cancellationToken);

		serviceResult.Result = cities
			.Select(current => new CityGetResponseDto
			{
				Id = current.Id,
				Name = current.Name,
				Description = current.Description,
				StateInfo = new StateGetResponseDto
				{
					Id = current.State.Id,
					Name = current.State.Name,
					Description = current.State.Description,
				},
			})
			.ToList();

		return serviceResult;
	}
}
