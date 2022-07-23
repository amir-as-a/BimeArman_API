namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class BlogTypeUpdateService : IBlogTypeUpdateService
{
	private readonly DatabaseContext databaseContext;

	public BlogTypeUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		BlogTypeCreateAndUpdateRequestDto blogTypeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var blogType = await databaseContext.BlogTypes
			.SingleOrDefaultAsync(current => current.Id == id);

		if (blogType is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "BlogType not found");
			return serviceResult;
		}

		blogType.Name = blogTypeCreateAndUpdateDto.Name;
		blogType.Ordering = blogTypeCreateAndUpdateDto.Ordering;
		blogType.IsActive = blogTypeCreateAndUpdateDto.IsActive;
		blogType.UpdateDateTime = DateTime.Now;

		databaseContext.Update(blogType);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
