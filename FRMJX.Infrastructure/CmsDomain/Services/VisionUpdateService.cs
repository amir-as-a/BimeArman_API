namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class VisionUpdateService : IVisionUpdateService
{
	private readonly DatabaseContext databaseContext;

	public VisionUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		VisionCreateAndUpdateRequestDto visionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var vision = await databaseContext.Visions
			.SingleOrDefaultAsync(current => current.Id == id);

		if (vision is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Vision not found");
			return serviceResult;
		}

		vision.Title = visionCreateAndUpdateDto.Title;
		vision.Description = visionCreateAndUpdateDto.Description;
		vision.CustomFileId = visionCreateAndUpdateDto.CustomFileId;
		vision.Ordering = visionCreateAndUpdateDto.Ordering;
		vision.IsActive = visionCreateAndUpdateDto.IsActive;
		vision.UpdateDateTime = DateTime.Now;

		databaseContext.Update(vision);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
