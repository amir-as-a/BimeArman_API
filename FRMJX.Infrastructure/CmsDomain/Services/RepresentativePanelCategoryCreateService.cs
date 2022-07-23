namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RepresentativePanelCategoryCreateService : IRepresentativePanelCategoryCreateService
{
	private readonly DatabaseContext databaseContext;

	public RepresentativePanelCategoryCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		RepresentativePanelCategoryCreateAndUpdateRequestDto representativePanelCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var representativePanelCategory = new RepresentativePanelCategory
		{
			CultureLcid = representativePanelCategoryCreateAndUpdateDto.CultureLcid,
			IsActive = representativePanelCategoryCreateAndUpdateDto.IsActive,
			Ordering = representativePanelCategoryCreateAndUpdateDto.Ordering,
			Title = representativePanelCategoryCreateAndUpdateDto.Title,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.RepresentativePanelCategories.Add(representativePanelCategory);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = representativePanelCategory.Id;

		return serviceResult;
	}
}
