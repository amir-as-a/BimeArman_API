namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class PersonnelPanelCategoryUpdateService : IPersonnelPanelCategoryUpdateService
{
	private readonly DatabaseContext databaseContext;

	public PersonnelPanelCategoryUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		PersonnelPanelCategoryCreateAndUpdateRequestDto personnelPanelCategoryCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var personnelPanelCategory = await databaseContext.PersonnelPanelCategories
			.SingleOrDefaultAsync(current => current.Id == id);

		if (personnelPanelCategory is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "PersonnelPanelCategory not found");
			return serviceResult;
		}

		personnelPanelCategory.Title = personnelPanelCategoryCreateAndUpdateDto.Title;
		personnelPanelCategory.Ordering = personnelPanelCategoryCreateAndUpdateDto.Ordering;
		personnelPanelCategory.IsActive = personnelPanelCategoryCreateAndUpdateDto.IsActive;
		personnelPanelCategory.UpdateDateTime = DateTime.Now;

		databaseContext.Update(personnelPanelCategory);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
