namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class ContactUsDeleteService : IContactUsDeleteService
{
	private readonly DatabaseContext databaseContext;

	public ContactUsDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var contactUs = databaseContext.ContactUs
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (contactUs is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(contactUs);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
