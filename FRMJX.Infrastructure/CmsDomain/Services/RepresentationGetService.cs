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

internal class RepresentationGetService : IRepresentationGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IStateGetService stateGetService;
	private readonly ICityGetService cityGetService;

	public RepresentationGetService(DatabaseContext databaseContext, IStateGetService stateGetService, ICityGetService cityGetService)
	{
		this.databaseContext = databaseContext;
		this.stateGetService = stateGetService;
		this.cityGetService = cityGetService;
	}

	public async Task<ServiceResult<RepresentationGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<RepresentationGetResponseDto>();

		var representation = await databaseContext.Representations
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (representation != null)
		{
			serviceResult.Result = new RepresentationGetResponseDto
			{
				Id = representation.Id,
				Ordering = representation.Ordering,
				IsActive = representation.IsActive,
				ExactAddress = representation.ExactAddress,
				BranchManager = representation.BranchManager,
				BranchName = representation.BranchName,
				PhoneNumber = representation.PhoneNumber,
				PostalCode = representation.PostalCode,
				CityId = representation.CityId,
				StateId = representation.StateId,
				StateInfo = stateGetService.GetById(representation.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(representation.CityId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<RepresentationGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentationGetResponseDto>>();

		var representations = await databaseContext.Representations
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representations
			.Select(current => new RepresentationGetResponseDto
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

	public async Task<ServiceResult<List<RepresentationGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentationGetResponseDto>>();

		var representations = await databaseContext.Representations
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representations
			.Select(current => new RepresentationGetResponseDto
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

	public async Task<ServiceResult<List<RepresentationGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentationGetResponseDto>>();

		var representations = await databaseContext.Representations
			.Where(current => current.StateId == stateId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representations
			.Select(current => new RepresentationGetResponseDto
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

	public async Task<ServiceResult<List<RepresentationGetResponseDto>>> GetByCity(int cityId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RepresentationGetResponseDto>>();

		var representations = await databaseContext.Representations
			.Where(current => current.CityId == cityId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = representations
			.Select(current => new RepresentationGetResponseDto
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
