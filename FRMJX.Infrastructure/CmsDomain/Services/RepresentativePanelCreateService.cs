namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RepresentativePanelCreateService : IRepresentativePanelCreateService
{
	private readonly DatabaseContext databaseContext;

	public RepresentativePanelCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		RepresentativePanelCreateAndUpdateRequestDto representativePanelCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var representativePanel = new RepresentativePanel
		{
			Title = representativePanelCreateAndUpdateDto.Title,
			PanelCategoryId = representativePanelCreateAndUpdateDto.PanelCategoryId,
			CustomFileId = representativePanelCreateAndUpdateDto.CustomFileId,
			Description = representativePanelCreateAndUpdateDto.Description,
			CultureLcid = representativePanelCreateAndUpdateDto.CultureLcid,
			IsActive = representativePanelCreateAndUpdateDto.IsActive,
			Ordering = representativePanelCreateAndUpdateDto.Ordering,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.RepresentativePanels.Add(representativePanel);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = representativePanel.Id;

		return serviceResult;
	}
}
