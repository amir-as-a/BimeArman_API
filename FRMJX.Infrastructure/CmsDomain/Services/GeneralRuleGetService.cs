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

internal class GeneralRuleGetService : IGeneralRuleGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public GeneralRuleGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<GeneralRuleGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<GeneralRuleGetResponseDto>();

		var generalRule = await databaseContext.GeneralRule
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (generalRule != null)
		{
			serviceResult.Result = new GeneralRuleGetResponseDto
			{
				Id = generalRule.Id,
				Ordering = generalRule.Ordering,
				IsActive = generalRule.IsActive,
				Title = generalRule.Title,
				Description = generalRule.Description,

			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<GeneralRuleGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<GeneralRuleGetResponseDto>>();

		var generalRules = await databaseContext.GeneralRule
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = generalRules
			.Select(current => new GeneralRuleGetResponseDto
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

	public async Task<ServiceResult<List<GeneralRuleGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<GeneralRuleGetResponseDto>>();

		var generalRules = await databaseContext.GeneralRule
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = generalRules
			.Select(current => new GeneralRuleGetResponseDto
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
