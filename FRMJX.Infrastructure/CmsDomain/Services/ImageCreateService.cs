namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class ImageCreateService : IImageCreateService
{
	private readonly DatabaseContext databaseContext;

	public ImageCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		ImageCreateAndUpdateRequestDto imageCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var image = new Image
		{
			CultureLcid = imageCreateAndUpdateDto.CultureLcid,
			IsActive = imageCreateAndUpdateDto.IsActive,
			Ordering = imageCreateAndUpdateDto.Ordering,
			Title = imageCreateAndUpdateDto.Title,
			Description = imageCreateAndUpdateDto.Description,
			CustomFileId = imageCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Images.Add(image);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = image.Id;

		return serviceResult;
	}
}
