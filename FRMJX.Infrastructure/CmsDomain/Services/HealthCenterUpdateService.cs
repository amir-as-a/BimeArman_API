namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class HealthCenterUpdateService : IHealthCenterUpdateService
{
	private readonly DatabaseContext databaseContext;

	public HealthCenterUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		HealthCenterCreateAndUpdateRequestDto healthCenterCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var healthCenter = await databaseContext.HealthCenters
			.SingleOrDefaultAsync(current => current.Id == id);

		if (healthCenter is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "HealthCenter not found");
			return serviceResult;
		}

		healthCenter.Center = healthCenterCreateAndUpdateDto.Center;
		healthCenter.CenterName = healthCenterCreateAndUpdateDto.CenterName;
		healthCenter.PhoneNumber = healthCenterCreateAndUpdateDto.PhoneNumber;
		healthCenter.CityId = healthCenterCreateAndUpdateDto.CityId;
		healthCenter.ExactAddress = healthCenterCreateAndUpdateDto.ExactAddress;
		healthCenter.Ordering = healthCenterCreateAndUpdateDto.Ordering;
		healthCenter.IsActive = healthCenterCreateAndUpdateDto.IsActive;
		healthCenter.UpdateDateTime = DateTime.Now;

		databaseContext.Update(healthCenter);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
