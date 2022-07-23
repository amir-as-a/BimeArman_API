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

internal class SaleRuleGetService : ISaleRuleGetService
{
	private readonly DatabaseContext databaseContext;

	public SaleRuleGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<SaleRuleGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<SaleRuleGetResponseDto>();

		var saleRule = await databaseContext.SaleRules
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (saleRule != null)
		{
			serviceResult.Result = new SaleRuleGetResponseDto
			{
				Id = saleRule.Id,
				Ordering = saleRule.Ordering,
				IsActive = saleRule.IsActive,
				Title = saleRule.Title,
				Description = saleRule.Description,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<SaleRuleGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SaleRuleGetResponseDto>>();

		var saleRules = await databaseContext.SaleRules
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = saleRules
			.Select(current => new SaleRuleGetResponseDto
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

	public async Task<ServiceResult<List<SaleRuleGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SaleRuleGetResponseDto>>();

		var saleRules = await databaseContext.SaleRules
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = saleRules
			.Select(current => new SaleRuleGetResponseDto
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
