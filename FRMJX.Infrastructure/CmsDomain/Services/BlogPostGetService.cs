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

internal class BlogPostGetService : IBlogPostGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public BlogPostGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<BlogPostGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<BlogPostGetResponseDto>();

		var blogPost = await databaseContext.BlogPosts
			.Where(current => current.Id == id)
			.OrderBy(current => current.Ordering)
			.Include(current => current.BlogType)
			.Include(current => current.BlogPostBlogCategories)
			.ThenInclude(x => x.BlogCategory)
			.SingleOrDefaultAsync(cancellationToken);

		if (blogPost != null)
		{
			serviceResult.Result = new BlogPostGetResponseDto
			{
				Id = blogPost.Id,
				Ordering = blogPost.Ordering,
				IsActive = blogPost.IsActive,
				Title = blogPost.Title,
				Body = blogPost.Body,
				InsertTime = blogPost.InsertDateTime,
				Picture = customFileGetService
						.GetById(blogPost.PictureId, CustomFileType.Image, cancellationToken).Result.Result,
				BlogTypeId = blogPost.BlogTypeId,
				BlogTypeName = blogPost.BlogType.Name,
				BlogCategories = blogPost.BlogPostBlogCategories.Select(m => new BlogCategoryGetResponseDto
				{
					Id = m.BlogCategory.Id,
					IsActive = m.BlogCategory.IsActive,
					Ordering = m.BlogCategory.Ordering,
					Name = m.BlogCategory.Name,
				}).ToList(),
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogPostGetResponseDto>>> GetActives(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogPostGetResponseDto>>();

		var blogPosts = await databaseContext.BlogPosts
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Include(current => current.BlogType)
			.Include(current => current.BlogPostBlogCategories)
			.ThenInclude(x => x.BlogCategory)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogPosts
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

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogPostGetResponseDto>>> GetAll(int cultureLcid,  bool isActive, CancellationToken cancellationToken, string? title = null)
	{
		var serviceResult = new ServiceResult<List<BlogPostGetResponseDto>>();

		var query = databaseContext.BlogPosts
			.Where(current => current.CultureLcid == cultureLcid && current.IsActive == isActive);

		if (!string.IsNullOrWhiteSpace(title))
		{
			title = title.Trim().ToLower();
			query = query.Where(x => x.Title.ToLower().Contains(title));
		}

		var blogPosts = await query.OrderBy(current => current.Ordering)
		.Include(current => current.BlogType)
		.Include(current => current.BlogPostBlogCategories)
		.ThenInclude(x => x.BlogCategory)
		.ToListAsync(cancellationToken);

		serviceResult.Result = blogPosts
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

		return serviceResult;
	}

	public async Task<ServiceResult<List<BlogPostGetResponseDto>>> GetlastBlogs(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<BlogPostGetResponseDto>>();

		var blogPosts = await databaseContext.BlogPosts
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderByDescending(current => current.InsertDateTime)
			.Include(current => current.BlogType)
			.Include(current => current.BlogPostBlogCategories)
			.ThenInclude(x => x.BlogCategory)
			.ToListAsync(cancellationToken);

		serviceResult.Result = blogPosts
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

		return serviceResult;
	}
}
