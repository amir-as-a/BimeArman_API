namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RepresentativePanelCategoryDeleteService : IRepresentativePanelCategoryDeleteService
{
	private readonly DatabaseContext databaseContext;

	public RepresentativePanelCategoryDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var representativePanelCategory = databaseContext.RepresentativePanelCategories
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (representativePanelCategory is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(representativePanelCategory);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
