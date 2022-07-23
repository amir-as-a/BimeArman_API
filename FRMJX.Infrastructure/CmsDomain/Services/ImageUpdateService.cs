namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class ImageUpdateService : IImageUpdateService
{
	private readonly DatabaseContext databaseContext;

	public ImageUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		ImageCreateAndUpdateRequestDto imageCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var image = await databaseContext.Images
			.SingleOrDefaultAsync(current => current.Id == id);

		if (image is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Image not found");
			return serviceResult;
		}

		image.Title = imageCreateAndUpdateDto.Title;
		image.Description = imageCreateAndUpdateDto.Description;
		image.CustomFileId = imageCreateAndUpdateDto.CustomFileId;
		image.Ordering = imageCreateAndUpdateDto.Ordering;
		image.IsActive = imageCreateAndUpdateDto.IsActive;
		image.UpdateDateTime = DateTime.Now;

		databaseContext.Update(image);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
