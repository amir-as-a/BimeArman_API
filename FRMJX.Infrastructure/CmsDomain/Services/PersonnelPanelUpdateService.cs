namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class PersonnelPanelUpdateService : IPersonnelPanelUpdateService
{
	private readonly DatabaseContext databaseContext;

	public PersonnelPanelUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		PersonnelPanelCreateAndUpdateRequestDto personnelPanelCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var personnelPanel = await databaseContext.PersonnelPanels
			.SingleOrDefaultAsync(current => current.Id == id);

		if (personnelPanel is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "PersonnelPanel not found");
			return serviceResult;
		}

		personnelPanel.Title = personnelPanelCreateAndUpdateDto.Title;
		personnelPanel.Description = personnelPanelCreateAndUpdateDto.Description;
		personnelPanel.CustomFileId = personnelPanelCreateAndUpdateDto.CustomFileId;
		personnelPanel.PanelCategoryId = personnelPanelCreateAndUpdateDto.PanelCategoryId;
		personnelPanel.Ordering = personnelPanelCreateAndUpdateDto.Ordering;
		personnelPanel.IsActive = personnelPanelCreateAndUpdateDto.IsActive;
		personnelPanel.UpdateDateTime = DateTime.Now;

		databaseContext.Update(personnelPanel);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
