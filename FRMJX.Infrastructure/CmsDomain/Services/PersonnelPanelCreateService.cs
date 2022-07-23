namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class PersonnelPanelCreateService : IPersonnelPanelCreateService
{
	private readonly DatabaseContext databaseContext;

	public PersonnelPanelCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		PersonnelPanelCreateAndUpdateRequestDto personnelPanelCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var personnelPanel = new PersonnelPanel
		{
			Title = personnelPanelCreateAndUpdateDto.Title,
			PanelCategoryId = personnelPanelCreateAndUpdateDto.PanelCategoryId,
			CustomFileId = personnelPanelCreateAndUpdateDto.CustomFileId,
			Description = personnelPanelCreateAndUpdateDto.Description,
			CultureLcid = personnelPanelCreateAndUpdateDto.CultureLcid,
			IsActive = personnelPanelCreateAndUpdateDto.IsActive,
			Ordering = personnelPanelCreateAndUpdateDto.Ordering,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.PersonnelPanels.Add(personnelPanel);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = personnelPanel.Id;

		return serviceResult;
	}
}
