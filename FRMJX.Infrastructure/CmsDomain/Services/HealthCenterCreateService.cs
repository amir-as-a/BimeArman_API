namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class HealthCenterCreateService : IHealthCenterCreateService
{
	private readonly DatabaseContext databaseContext;

	public HealthCenterCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		HealthCenterCreateAndUpdateRequestDto healthCenterCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var healthCenter = new HealthCenter
		{
			CultureLcid = healthCenterCreateAndUpdateDto.CultureLcid,
			IsActive = healthCenterCreateAndUpdateDto.IsActive,
			Ordering = healthCenterCreateAndUpdateDto.Ordering,
			Center = healthCenterCreateAndUpdateDto.Center,
			CenterName = healthCenterCreateAndUpdateDto.CenterName,
			PhoneNumber = healthCenterCreateAndUpdateDto.PhoneNumber,
			CityId = healthCenterCreateAndUpdateDto.CityId,
			ExactAddress = healthCenterCreateAndUpdateDto.ExactAddress,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.HealthCenters.Add(healthCenter);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = healthCenter.Id;

		return serviceResult;
	}
}
