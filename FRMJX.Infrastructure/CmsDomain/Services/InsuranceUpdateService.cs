namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class InsuranceUpdateService : IInsuranceUpdateService
{
	private readonly DatabaseContext databaseContext;

	public InsuranceUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		InsuranceCreateAndUpdateRequestDto insuranceCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var insurance = await databaseContext.Insurances
			.SingleOrDefaultAsync(current => current.Id == id);

		if (insurance is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Insurance not found");
			return serviceResult;
		}

		insurance.Title = insuranceCreateAndUpdateDto.Title;
		insurance.Description = insuranceCreateAndUpdateDto.Description;
		insurance.ImageId = insuranceCreateAndUpdateDto.ImageId;
		insurance.IconId = insuranceCreateAndUpdateDto.IconId;
		insurance.Ordering = insuranceCreateAndUpdateDto.Ordering;
		insurance.IsActive = insuranceCreateAndUpdateDto.IsActive;
		insurance.UpdateDateTime = DateTime.Now;

		databaseContext.Update(insurance);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
