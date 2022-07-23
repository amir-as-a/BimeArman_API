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

internal class CommonGetService : ICommonGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public CommonGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<SearchResponseDto>> Search(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken, string? title = null)
	{
		var serviceResult = new ServiceResult<SearchResponseDto>();

		serviceResult.Result = new SearchResponseDto();

		var blogPostQuery = databaseContext.BlogPosts
			.Where(current => current.CultureLcid == cultureLcid);

		if (!string.IsNullOrWhiteSpace(title))
		{
			blogPostQuery = blogPostQuery.Where(x => x.Title.Contains(title));
		}

		var blogPosts = await blogPostQuery.OrderBy(current => current.Ordering)
				.Include(current => current.BlogType)
				.Include(current => current.BlogPostBlogCategories)
				.ThenInclude(x => x.BlogCategory)
				.ToListAsync(cancellationToken);

		var blogResults = blogPosts
			.Select(current => new BlogPostGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Body = current.Body,
				InsertTime = current.InsertDateTime,
				Picture = customFileGetService
					.GetById(current.PictureId, CustomFileType.Image, cancellationToken).Result.Result,
				BlogTypeId = current.BlogTypeId,
				BlogTypeName = current.BlogType.Name,
				BlogCategories = current.BlogPostBlogCategories.Select(m => new BlogCategoryGetResponseDto
				{
					Id = m.BlogCategory.Id,
					IsActive = m.BlogCategory.IsActive,
					Ordering = m.BlogCategory.Ordering,
					Name = m.BlogCategory.Name,
				}).ToList(),
			})
			.ToList();

		var insuranceQuery = databaseContext.Insurances
			.Where(current => current.CultureLcid == cultureLcid);

		if (!string.IsNullOrWhiteSpace(title))
		{
			insuranceQuery = insuranceQuery.Where(x => x.Title.Contains(title));
		}

		var insurances = await insuranceQuery.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		var insuranceResults = insurances
			.Select(current => new InsuranceGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				ImageInfo = current.ImageId is not null ? customFileGetService.GetById((int)current.ImageId, CustomFileType.Image, cancellationToken).Result.Result : null,
				IconInfo = customFileGetService.GetById(current.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		serviceResult.Result.BlogPosts = blogResults;

		serviceResult.Result.Insurances = insuranceResults;

		return serviceResult;
	}
}
