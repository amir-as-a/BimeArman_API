namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class GeneralRuleUpdateService : IGeneralRuleUpdateService
{
	private readonly DatabaseContext databaseContext;

	public GeneralRuleUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		GeneralRuleCreateAndUpdateRequestDto generalRuleCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var generalRule = await databaseContext.GeneralRule
			.SingleOrDefaultAsync(current => current.Id == id);

		if (generalRule is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "GeneralRule not found");
			return serviceResult;
		}

		generalRule.Title = generalRuleCreateAndUpdateDto.Title;
		generalRule.Description = generalRuleCreateAndUpdateDto.Description;
		generalRule.Ordering = generalRuleCreateAndUpdateDto.Ordering;
		generalRule.IsActive = generalRuleCreateAndUpdateDto.IsActive;
		generalRule.UpdateDateTime = DateTime.Now;

		databaseContext.Update(generalRule);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
