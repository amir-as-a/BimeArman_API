namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RepresentationConditionUpdateService : IRepresentationConditionUpdateService
{
	private readonly DatabaseContext databaseContext;

	public RepresentationConditionUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		RepresentationConditionCreateAndUpdateRequestDto representationConditionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var representationCondition = await databaseContext.RepresentationConditions
			.SingleOrDefaultAsync(current => current.Id == id);

		if (representationCondition is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "RepresentationCondition not found");
			return serviceResult;
		}

		representationCondition.Title = representationConditionCreateAndUpdateDto.Title;
		representationCondition.Description = representationConditionCreateAndUpdateDto.Description;
		representationCondition.Ordering = representationConditionCreateAndUpdateDto.Ordering;
		representationCondition.IsActive = representationConditionCreateAndUpdateDto.IsActive;
		representationCondition.UpdateDateTime = DateTime.Now;

		databaseContext.Update(representationCondition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
