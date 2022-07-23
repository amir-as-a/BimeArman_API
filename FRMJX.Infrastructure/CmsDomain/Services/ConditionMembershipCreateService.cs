namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class ConditionMembershipCreateService : IConditionMembershipCreateService
{
	private readonly DatabaseContext databaseContext;

	public ConditionMembershipCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		ConditionMembershipCreateAndUpdateRequestDto conditionMembershipCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var conditionMembership = new ConditionMembership
		{
			CultureLcid = conditionMembershipCreateAndUpdateDto.CultureLcid,
			IsActive = conditionMembershipCreateAndUpdateDto.IsActive,
			Ordering = conditionMembershipCreateAndUpdateDto.Ordering,
			Title = conditionMembershipCreateAndUpdateDto.Title,
			CustomFileId = conditionMembershipCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.ConditionMembership.Add(conditionMembership);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = conditionMembership.Id;

		return serviceResult;
	}
}
