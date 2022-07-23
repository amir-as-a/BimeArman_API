namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class GeneralConditionCreateService : IGeneralConditionCreateService
{
	private readonly DatabaseContext databaseContext;

	public GeneralConditionCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		GeneralConditionCreateAndUpdateRequestDto generalConditionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var generalCondition = new GeneralCondition
		{
			CultureLcid = generalConditionCreateAndUpdateDto.CultureLcid,
			IsActive = generalConditionCreateAndUpdateDto.IsActive,
			Ordering = generalConditionCreateAndUpdateDto.Ordering,
			Title = generalConditionCreateAndUpdateDto.Title,
			Description = generalConditionCreateAndUpdateDto.Description,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.GeneralCondition.Add(generalCondition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = generalCondition.Id;

		return serviceResult;
	}
}
