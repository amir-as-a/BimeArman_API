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

internal class FaqGetService : IFaqGetService
{
	private readonly DatabaseContext databaseContext;

	public FaqGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<FaqGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<FaqGetResponseDto>();

		var faq = await databaseContext.Faqs
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (faq != null)
		{
			serviceResult.Result = new FaqGetResponseDto
			{
				Id = faq.Id,
				Ordering = faq.Ordering,
				IsActive = faq.IsActive,
				Question = faq.Question,
				Answer = faq.Answer,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<FaqGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<FaqGetResponseDto>>();

		var faqs = await databaseContext.Faqs
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = faqs
			.Select(current => new FaqGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Question = current.Question,
				Answer = current.Answer,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<FaqGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<FaqGetResponseDto>>();

		var faqs = await databaseContext.Faqs
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = faqs
			.Select(current => new FaqGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Question = current.Question,
				Answer = current.Answer,
			})
			.ToList();

		return serviceResult;
	}
}
