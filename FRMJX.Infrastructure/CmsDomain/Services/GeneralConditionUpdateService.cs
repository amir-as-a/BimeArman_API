namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class GeneralConditionUpdateService : IGeneralConditionUpdateService
{
	private readonly DatabaseContext databaseContext;

	public GeneralConditionUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		GeneralConditionCreateAndUpdateRequestDto generalConditionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var generalCondition = await databaseContext.GeneralCondition
			.SingleOrDefaultAsync(current => current.Id == id);

		if (generalCondition is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "GeneralCondition not found");
			return serviceResult;
		}

		generalCondition.Title = generalConditionCreateAndUpdateDto.Title;
		generalCondition.Description = generalConditionCreateAndUpdateDto.Description;
		generalCondition.Ordering = generalConditionCreateAndUpdateDto.Ordering;
		generalCondition.IsActive = generalConditionCreateAndUpdateDto.IsActive;
		generalCondition.UpdateDateTime = DateTime.Now;

		databaseContext.Update(generalCondition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
