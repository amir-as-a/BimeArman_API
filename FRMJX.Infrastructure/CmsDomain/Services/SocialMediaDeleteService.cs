namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SocialMediaDeleteService : ISocialMediaDeleteService
{
	private readonly DatabaseContext databaseContext;

	public SocialMediaDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var socialMedia = databaseContext.SocialMedia
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (socialMedia is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(socialMedia);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
