namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RepresentativePanelUpdateService : IRepresentativePanelUpdateService
{
	private readonly DatabaseContext databaseContext;

	public RepresentativePanelUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		RepresentativePanelCreateAndUpdateRequestDto representativePanelCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var representativePanel = await databaseContext.RepresentativePanels
			.SingleOrDefaultAsync(current => current.Id == id);

		if (representativePanel is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "RepresentativePanel not found");
			return serviceResult;
		}

		representativePanel.Title = representativePanelCreateAndUpdateDto.Title;
		representativePanel.Description = representativePanelCreateAndUpdateDto.Description;
		representativePanel.CustomFileId = representativePanelCreateAndUpdateDto.CustomFileId;
		representativePanel.PanelCategoryId = representativePanelCreateAndUpdateDto.PanelCategoryId;
		representativePanel.Ordering = representativePanelCreateAndUpdateDto.Ordering;
		representativePanel.IsActive = representativePanelCreateAndUpdateDto.IsActive;
		representativePanel.UpdateDateTime = DateTime.Now;

		databaseContext.Update(representativePanel);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
