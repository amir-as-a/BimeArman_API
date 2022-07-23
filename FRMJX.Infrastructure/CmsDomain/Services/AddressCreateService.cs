namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class AddressCreateService : IAddressCreateService
{
	private readonly DatabaseContext databaseContext;

	public AddressCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		AddressCreateAndUpdateRequestDto addressCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var address = new Address
		{
			CultureLcid = addressCreateAndUpdateDto.CultureLcid,
			IsActive = addressCreateAndUpdateDto.IsActive,
			Ordering = addressCreateAndUpdateDto.Ordering,
			CityId = addressCreateAndUpdateDto.CityId,
			StateId = addressCreateAndUpdateDto.StateId,
			ExactAddress = addressCreateAndUpdateDto.ExactAddress,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Addresses.Add(address);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = address.Id;

		return serviceResult;
	}
}
