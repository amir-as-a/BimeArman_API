namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class VisionAttributeUpdateService : IVisionAttributeUpdateService
{
	private readonly DatabaseContext databaseContext;

	public VisionAttributeUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		VisionAttributeCreateAndUpdateRequestDto visionAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var visionAttribute = await databaseContext.VisionAttributes
			.SingleOrDefaultAsync(current => current.Id == id);

		if (visionAttribute is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "VisionAttribute not found");
			return serviceResult;
		}

		visionAttribute.Title = visionAttributeCreateAndUpdateDto.Title;
		visionAttribute.Ordering = visionAttributeCreateAndUpdateDto.Ordering;
		visionAttribute.IsActive = visionAttributeCreateAndUpdateDto.IsActive;
		visionAttribute.UpdateDateTime = DateTime.Now;

		databaseContext.Update(visionAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
