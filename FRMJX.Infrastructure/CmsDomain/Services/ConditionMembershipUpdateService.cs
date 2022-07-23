namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class ConditionMembershipUpdateService : IConditionMembershipUpdateService
{
	private readonly DatabaseContext databaseContext;

	public ConditionMembershipUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		ConditionMembershipCreateAndUpdateRequestDto conditionMembershipCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var conditionMembership = await databaseContext.ConditionMembership
			.SingleOrDefaultAsync(current => current.Id == id);

		if (conditionMembership is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "ConditionMembership not found");
			return serviceResult;
		}

		conditionMembership.Title = conditionMembershipCreateAndUpdateDto.Title;
		conditionMembership.CustomFileId = conditionMembershipCreateAndUpdateDto.CustomFileId;
		conditionMembership.Ordering = conditionMembershipCreateAndUpdateDto.Ordering;
		conditionMembership.IsActive = conditionMembershipCreateAndUpdateDto.IsActive;
		conditionMembership.UpdateDateTime = DateTime.Now;

		databaseContext.Update(conditionMembership);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
