namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class PersonnelPanelCategoryCreateService : IPersonnelPanelCategoryCreateService
{
	private readonly DatabaseContext databaseContext;

	public PersonnelPanelCategoryCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		PersonnelPanelCategoryCreateAndUpdateRequestDto personnelPanelCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var personnelPanelCategory = new PersonnelPanelCategory
		{
			CultureLcid = personnelPanelCategoryCreateAndUpdateDto.CultureLcid,
			IsActive = personnelPanelCategoryCreateAndUpdateDto.IsActive,
			Ordering = personnelPanelCategoryCreateAndUpdateDto.Ordering,
			Title = personnelPanelCategoryCreateAndUpdateDto.Title,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.PersonnelPanelCategories.Add(personnelPanelCategory);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = personnelPanelCategory.Id;

		return serviceResult;
	}
}
