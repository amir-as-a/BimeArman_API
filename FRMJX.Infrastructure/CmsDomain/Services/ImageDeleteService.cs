namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class ImageDeleteService : IImageDeleteService
{
	private readonly DatabaseContext databaseContext;

	public ImageDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var image = databaseContext.Images
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (image is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(image);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
