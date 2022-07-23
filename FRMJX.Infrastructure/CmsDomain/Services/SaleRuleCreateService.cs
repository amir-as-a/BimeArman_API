namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class SaleRuleCreateService : ISaleRuleCreateService
{
	private readonly DatabaseContext databaseContext;

	public SaleRuleCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		SaleRuleCreateAndUpdateRequestDto saleRuleCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var saleRule = new SaleRule
		{
			CultureLcid = saleRuleCreateAndUpdateDto.CultureLcid,
			IsActive = saleRuleCreateAndUpdateDto.IsActive,
			Ordering = saleRuleCreateAndUpdateDto.Ordering,
			Title = saleRuleCreateAndUpdateDto.Title,
			Description = saleRuleCreateAndUpdateDto.Description,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.SaleRules.Add(saleRule);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = saleRule.Id;

		return serviceResult;
	}
}
