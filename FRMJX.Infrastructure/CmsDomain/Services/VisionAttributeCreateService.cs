namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class VisionAttributeCreateService : IVisionAttributeCreateService
{
	private readonly DatabaseContext databaseContext;

	public VisionAttributeCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		VisionAttributeCreateAndUpdateRequestDto visionAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var visionAttribute = new VisionAttribute
		{
			CultureLcid = visionAttributeCreateAndUpdateDto.CultureLcid,
			IsActive = visionAttributeCreateAndUpdateDto.IsActive,
			Ordering = visionAttributeCreateAndUpdateDto.Ordering,
			Title = visionAttributeCreateAndUpdateDto.Title,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.VisionAttributes.Add(visionAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = visionAttribute.Id;

		return serviceResult;
	}
}
