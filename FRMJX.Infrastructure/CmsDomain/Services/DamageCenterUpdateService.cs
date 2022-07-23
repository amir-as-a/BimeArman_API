namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class DamageCenterUpdateService : IDamageCenterUpdateService
{
	private readonly DatabaseContext databaseContext;

	public DamageCenterUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		DamageCenterCreateAndUpdateRequestDto damageCenterCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var damageCenter = await databaseContext.DamageCenters
			.SingleOrDefaultAsync(current => current.Id == id);

		if (damageCenter is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "DamageCenter not found");
			return serviceResult;
		}

		damageCenter.CityId = damageCenterCreateAndUpdateDto.CityId;
		damageCenter.StateId = damageCenterCreateAndUpdateDto.StateId;
		damageCenter.ExactAddress = damageCenterCreateAndUpdateDto.ExactAddress;
		damageCenter.BranchManager = damageCenterCreateAndUpdateDto.BranchManager;
		damageCenter.BranchName = damageCenterCreateAndUpdateDto.BranchName;
		damageCenter.PhoneNumber = damageCenterCreateAndUpdateDto.PhoneNumber;
		damageCenter.PostalCode = damageCenterCreateAndUpdateDto.PostalCode;
		damageCenter.Ordering = damageCenterCreateAndUpdateDto.Ordering;
		damageCenter.IsActive = damageCenterCreateAndUpdateDto.IsActive;
		damageCenter.UpdateDateTime = DateTime.Now;

		databaseContext.Update(damageCenter);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
