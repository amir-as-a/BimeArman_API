namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RepresentationConditionCreateService : IRepresentationConditionCreateService
{
	private readonly DatabaseContext databaseContext;

	public RepresentationConditionCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		RepresentationConditionCreateAndUpdateRequestDto representationConditionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var representationCondition = new RepresentationCondition
		{
			CultureLcid = representationConditionCreateAndUpdateDto.CultureLcid,
			IsActive = representationConditionCreateAndUpdateDto.IsActive,
			Ordering = representationConditionCreateAndUpdateDto.Ordering,
			Title = representationConditionCreateAndUpdateDto.Title,
			Description = representationConditionCreateAndUpdateDto.Description,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.RepresentationConditions.Add(representationCondition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = representationCondition.Id;

		return serviceResult;
	}
}
