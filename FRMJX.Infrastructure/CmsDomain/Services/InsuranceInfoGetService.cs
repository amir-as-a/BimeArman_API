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

internal class InsuranceInfoGetService : IInsuranceInfoGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IInsuranceGetService insuranceGetService;

	public InsuranceInfoGetService(DatabaseContext databaseContext, IInsuranceGetService insuranceGetService)
	{
		this.databaseContext = databaseContext;
		this.insuranceGetService = insuranceGetService;
	}

	public async Task<ServiceResult<InsuranceInfoGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<InsuranceInfoGetResponseDto>();

		var insuranceInfo = await databaseContext.InsuranceInfos
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (insuranceInfo != null)
		{
			serviceResult.Result = new InsuranceInfoGetResponseDto
			{
				Id = insuranceInfo.Id,
				Ordering = insuranceInfo.Ordering,
				IsActive = insuranceInfo.IsActive,
				Title = insuranceInfo.Title,
				Description = insuranceInfo.Description,
				InsuranceDetail = insuranceGetService.GetById(insuranceInfo.InsuranceId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<InsuranceInfoGetResponseDto>>> GetByInsuranceId(int insuranceId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<InsuranceInfoGetResponseDto>>();

		var insuranceInfos = await databaseContext.InsuranceInfos
			.Where(current => current.Id == insuranceId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = insuranceInfos
			.Select(current => new InsuranceInfoGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				InsuranceDetail = insuranceGetService.GetById(current.InsuranceId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<InsuranceInfoGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<InsuranceInfoGetResponseDto>>();

		var insuranceInfos = await databaseContext.InsuranceInfos
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = insuranceInfos
			.Select(current => new InsuranceInfoGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				InsuranceDetail = insuranceGetService.GetById(current.InsuranceId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<InsuranceInfoGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<InsuranceInfoGetResponseDto>>();

		var insuranceInfos = await databaseContext.InsuranceInfos
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = insuranceInfos
			.Select(current => new InsuranceInfoGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				InsuranceDetail = insuranceGetService.GetById(current.InsuranceId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
