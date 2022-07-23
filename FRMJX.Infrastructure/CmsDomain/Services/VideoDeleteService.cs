namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class VideoDeleteService : IVideoDeleteService
{
	private readonly DatabaseContext databaseContext;

	public VideoDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var video = databaseContext.Videos
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (video is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(video);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
