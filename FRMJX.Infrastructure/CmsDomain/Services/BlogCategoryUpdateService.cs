namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class BlogCategoryUpdateService : IBlogCategoryUpdateService
{
	private readonly DatabaseContext databaseContext;

	public BlogCategoryUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		BlogCategoryCreateAndUpdateRequestDto blogCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogCategory = await databaseContext.BlogCategories
			.SingleOrDefaultAsync(current => current.Id == id);

		if (blogCategory is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "BlogCategory not found");
			return serviceResult;
		}

		blogCategory.Name = blogCategoryCreateAndUpdateDto.Name;
		blogCategory.Ordering = blogCategoryCreateAndUpdateDto.Ordering;
		blogCategory.IsActive = blogCategoryCreateAndUpdateDto.IsActive;
		blogCategory.UpdateDateTime = DateTime.Now;

		databaseContext.Update(blogCategory);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
