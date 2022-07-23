namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class VisionCreateService : IVisionCreateService
{
	private readonly DatabaseContext databaseContext;

	public VisionCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		VisionCreateAndUpdateRequestDto visionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var vision = new Vision
		{
			CultureLcid = visionCreateAndUpdateDto.CultureLcid,
			IsActive = visionCreateAndUpdateDto.IsActive,
			Ordering = visionCreateAndUpdateDto.Ordering,
			Title = visionCreateAndUpdateDto.Title,
			Description = visionCreateAndUpdateDto.Description,
			CustomFileId = visionCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Visions.Add(vision);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = vision.Id;

		return serviceResult;
	}
}
