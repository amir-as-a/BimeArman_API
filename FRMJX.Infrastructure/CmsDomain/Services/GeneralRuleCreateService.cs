namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class GeneralRuleCreateService : IGeneralRuleCreateService
{
	private readonly DatabaseContext databaseContext;

	public GeneralRuleCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		GeneralRuleCreateAndUpdateRequestDto generalRuleCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var generalRule = new GeneralRule
		{
			CultureLcid = generalRuleCreateAndUpdateDto.CultureLcid,
			IsActive = generalRuleCreateAndUpdateDto.IsActive,
			Ordering = generalRuleCreateAndUpdateDto.Ordering,
			Title = generalRuleCreateAndUpdateDto.Title,
			Description = generalRuleCreateAndUpdateDto.Description,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.GeneralRule.Add(generalRule);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = generalRule.Id;

		return serviceResult;
	}
}
