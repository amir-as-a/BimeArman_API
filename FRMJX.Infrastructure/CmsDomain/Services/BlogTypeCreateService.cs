namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class BlogTypeCreateService : IBlogTypeCreateService
{
	private readonly DatabaseContext databaseContext;

	public BlogTypeCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		BlogTypeCreateAndUpdateRequestDto blogTypeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var blogType = new BlogType
		{
			CultureLcid = blogTypeCreateAndUpdateDto.CultureLcid,
			IsActive = blogTypeCreateAndUpdateDto.IsActive,
			Ordering = blogTypeCreateAndUpdateDto.Ordering,
			Name = blogTypeCreateAndUpdateDto.Name,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.BlogTypes.Add(blogType);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = blogType.Id;

		return serviceResult;
	}
}
