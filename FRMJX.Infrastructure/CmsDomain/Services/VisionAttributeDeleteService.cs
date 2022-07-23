namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class VisionAttributeDeleteService : IVisionAttributeDeleteService
{
	private readonly DatabaseContext databaseContext;

	public VisionAttributeDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var visionAttribute = databaseContext.VisionAttributes
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (visionAttribute is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(visionAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
