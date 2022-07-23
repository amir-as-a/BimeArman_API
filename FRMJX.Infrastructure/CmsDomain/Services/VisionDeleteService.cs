namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class VisionDeleteService : IVisionDeleteService
{
	private readonly DatabaseContext databaseContext;

	public VisionDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var vision = databaseContext.Visions
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (vision is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(vision);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
