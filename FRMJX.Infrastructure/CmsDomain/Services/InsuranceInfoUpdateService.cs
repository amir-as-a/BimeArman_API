namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class InsuranceInfoUpdateService : IInsuranceInfoUpdateService
{
	private readonly DatabaseContext databaseContext;

	public InsuranceInfoUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		InsuranceInfoCreateAndUpdateRequestDto insuranceInfoCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var insuranceInfo = await databaseContext.InsuranceInfos
			.SingleOrDefaultAsync(current => current.Id == id);

		if (insuranceInfo is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "InsuranceInfo not found");
			return serviceResult;
		}

		insuranceInfo.Title = insuranceInfoCreateAndUpdateDto.Title;
		insuranceInfo.Description = insuranceInfoCreateAndUpdateDto.Description;
		insuranceInfo.InsuranceId = insuranceInfoCreateAndUpdateDto.InsuranceId;
		insuranceInfo.Ordering = insuranceInfoCreateAndUpdateDto.Ordering;
		insuranceInfo.IsActive = insuranceInfoCreateAndUpdateDto.IsActive;
		insuranceInfo.UpdateDateTime = DateTime.Now;

		databaseContext.Update(insuranceInfo);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
