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

internal class BlogTypeGetService : IBlogTypeGetService
{
	private readonly DatabaseContext databaseContext;

	public BlogTypeGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<BlogTypeGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<BlogTypeGetResponseDto>();

		var blogType = await databaseContext.BlogTypes
			.Where(current => current.Id == id)
			.OrderBy(current => current.Ordering)
			.SingleOrDefaultAsync(cancellationToken);

		serviceResult.Result = new BlogTypeGetResponseDto
			{
				Id = blogType.Id,
				Name = blogType.Name,
				Ordering = blogType.Ordering,
				IsActive = blogType.IsActive,
			};

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogTypeGetResponseDto>>> GetActives(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogTypeGetResponseDto>>();

		var blogTypes = await databaseContext.BlogTypes
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogTypes
			.Select(current => new BlogTypeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogTypeGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogTypeGetResponseDto>>();

		var blogTypes = await databaseContext.BlogTypes
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogTypes
			.Select(current => new BlogTypeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}
}
