namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class InsuranceInfoCreateService : IInsuranceInfoCreateService
{
	private readonly DatabaseContext databaseContext;

	public InsuranceInfoCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		InsuranceInfoCreateAndUpdateRequestDto insuranceInfoCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var insuranceInfo = new InsuranceInfo
		{
			CultureLcid = insuranceInfoCreateAndUpdateDto.CultureLcid,
			IsActive = insuranceInfoCreateAndUpdateDto.IsActive,
			Ordering = insuranceInfoCreateAndUpdateDto.Ordering,
			Title = insuranceInfoCreateAndUpdateDto.Title,
			Description = insuranceInfoCreateAndUpdateDto.Description,
			InsuranceId = insuranceInfoCreateAndUpdateDto.InsuranceId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.InsuranceInfos.Add(insuranceInfo);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = insuranceInfo.Id;

		return serviceResult;
	}
}
