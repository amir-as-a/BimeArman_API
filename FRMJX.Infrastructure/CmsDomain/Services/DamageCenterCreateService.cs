namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class DamageCenterCreateService : IDamageCenterCreateService
{
	private readonly DatabaseContext databaseContext;

	public DamageCenterCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		DamageCenterCreateAndUpdateRequestDto damageCenterCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var damageCenter = new DamageCenter
		{
			BranchName = damageCenterCreateAndUpdateDto.BranchName,
			BranchManager = damageCenterCreateAndUpdateDto.BranchManager,
			PhoneNumber = damageCenterCreateAndUpdateDto.PhoneNumber,
			CultureLcid = damageCenterCreateAndUpdateDto.CultureLcid,
			IsActive = damageCenterCreateAndUpdateDto.IsActive,
			Ordering = damageCenterCreateAndUpdateDto.Ordering,
			CityId = damageCenterCreateAndUpdateDto.CityId,
			StateId = damageCenterCreateAndUpdateDto.StateId,
			ExactAddress = damageCenterCreateAndUpdateDto.ExactAddress,
			PostalCode = damageCenterCreateAndUpdateDto.PostalCode,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.DamageCenters.Add(damageCenter);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = damageCenter.Id;

		return serviceResult;
	}
}
