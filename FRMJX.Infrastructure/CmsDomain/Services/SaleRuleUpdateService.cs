namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SaleRuleUpdateService : ISaleRuleUpdateService
{
	private readonly DatabaseContext databaseContext;

	public SaleRuleUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		SaleRuleCreateAndUpdateRequestDto saleRuleCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var saleRule = await databaseContext.SaleRules
			.SingleOrDefaultAsync(current => current.Id == id);

		if (saleRule is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "SaleRule not found");
			return serviceResult;
		}

		saleRule.Title = saleRuleCreateAndUpdateDto.Title;
		saleRule.Description = saleRuleCreateAndUpdateDto.Description;
		saleRule.Ordering = saleRuleCreateAndUpdateDto.Ordering;
		saleRule.IsActive = saleRuleCreateAndUpdateDto.IsActive;
		saleRule.UpdateDateTime = DateTime.Now;

		databaseContext.Update(saleRule);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
