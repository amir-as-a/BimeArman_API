namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RepresentativePanelCategoryUpdateService : IRepresentativePanelCategoryUpdateService
{
	private readonly DatabaseContext databaseContext;

	public RepresentativePanelCategoryUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		RepresentativePanelCategoryCreateAndUpdateRequestDto representativePanelCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var representativePanelCategory = await databaseContext.RepresentativePanelCategories
			.SingleOrDefaultAsync(current => current.Id == id);

		if (representativePanelCategory is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "RepresentativePanelCategory not found");
			return serviceResult;
		}

		representativePanelCategory.Title = representativePanelCategoryCreateAndUpdateDto.Title;
		representativePanelCategory.Ordering = representativePanelCategoryCreateAndUpdateDto.Ordering;
		representativePanelCategory.IsActive = representativePanelCategoryCreateAndUpdateDto.IsActive;
		representativePanelCategory.UpdateDateTime = DateTime.Now;

		databaseContext.Update(representativePanelCategory);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
