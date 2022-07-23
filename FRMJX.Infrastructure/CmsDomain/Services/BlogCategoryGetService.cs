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

internal class BlogCategoryGetService : IBlogCategoryGetService
{
	private readonly DatabaseContext databaseContext;

	public BlogCategoryGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<BlogCategoryGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<BlogCategoryGetResponseDto>();

		var blogCategory = await databaseContext.BlogCategories
			.Where(current => current.Id == id)
			.OrderBy(current => current.Ordering)
			.SingleOrDefaultAsync(cancellationToken);

		if (blogCategory != null)
		{
			serviceResult.Result = new BlogCategoryGetResponseDto
			{
				Id = blogCategory.Id,
				Name = blogCategory.Name,
				Ordering = blogCategory.Ordering,
				IsActive = blogCategory.IsActive,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogCategoryGetResponseDto>>> GetActives(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogCategoryGetResponseDto>>();

		var blogCategories = await databaseContext.BlogCategories
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogCategories
			.Select(current => new BlogCategoryGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogCategoryGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogCategoryGetResponseDto>>();

		var blogCategories = await databaseContext.BlogCategories
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogCategories
			.Select(current => new BlogCategoryGetResponseDto
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
