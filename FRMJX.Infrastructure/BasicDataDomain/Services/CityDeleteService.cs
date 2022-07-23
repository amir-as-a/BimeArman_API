namespace FRMJX.Infrastructure.BasicDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class CityDeleteService : ICityDeleteService
{
	private readonly DatabaseContext databaseContext;

	public CityDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(long id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var city = databaseContext.City
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (city is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(city);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
