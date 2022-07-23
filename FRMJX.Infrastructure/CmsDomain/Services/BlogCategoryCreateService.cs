namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class BlogCategoryCreateService : IBlogCategoryCreateService
{
	private readonly DatabaseContext databaseContext;

	public BlogCategoryCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		BlogCategoryCreateAndUpdateRequestDto blogCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var blogCategory = new BlogCategory
		{
			CultureLcid = blogCategoryCreateAndUpdateDto.CultureLcid,
			IsActive = blogCategoryCreateAndUpdateDto.IsActive,
			Ordering = blogCategoryCreateAndUpdateDto.Ordering,
			Name = blogCategoryCreateAndUpdateDto.Name,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.BlogCategories.Add(blogCategory);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = blogCategory.Id;

		return serviceResult;
	}
}
