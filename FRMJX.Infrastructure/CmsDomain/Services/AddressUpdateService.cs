namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class AddressUpdateService : IAddressUpdateService
{
	private readonly DatabaseContext databaseContext;

	public AddressUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		AddressCreateAndUpdateRequestDto addressCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var address = await databaseContext.Addresses
			.SingleOrDefaultAsync(current => current.Id == id);

		if (address is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Address not found");
			return serviceResult;
		}

		address.CityId = addressCreateAndUpdateDto.CityId;
		address.StateId = addressCreateAndUpdateDto.StateId;
		address.ExactAddress = addressCreateAndUpdateDto.ExactAddress;
		address.Ordering = addressCreateAndUpdateDto.Ordering;
		address.IsActive = addressCreateAndUpdateDto.IsActive;
		address.UpdateDateTime = DateTime.Now;

		databaseContext.Update(address);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
