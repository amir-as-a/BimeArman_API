namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class AddressDeleteService : IAddressDeleteService
{
	private readonly DatabaseContext databaseContext;

	public AddressDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var address = databaseContext.Addresses
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (address is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(address);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
