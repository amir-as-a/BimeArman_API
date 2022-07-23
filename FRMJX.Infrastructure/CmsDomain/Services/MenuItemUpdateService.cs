namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class MenuItemUpdateService : IMenuItemUpdateService
{
	private readonly DatabaseContext databaseContext;

	public MenuItemUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		MenuItemCreateAndUpdateRequestDto menuItemCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var menuItem = await databaseContext.MenuItems
			.SingleOrDefaultAsync(current => current.Id == id);

		if (menuItem is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "MenuItem not found");
			return serviceResult;
		}

		menuItem.Title = menuItemCreateAndUpdateDto.Title;
		menuItem.Url = menuItemCreateAndUpdateDto.Url;
		menuItem.OpenInNewTab = menuItemCreateAndUpdateDto.OpenInNewTab;
		menuItem.Ordering = menuItemCreateAndUpdateDto.Ordering;
		menuItem.IsActive = menuItemCreateAndUpdateDto.IsActive;
		menuItem.FirstFooter = menuItemCreateAndUpdateDto.FirstFooter;
		menuItem.SecendFooter = menuItemCreateAndUpdateDto.SecendFooter;
		menuItem.ThirdFooter = menuItemCreateAndUpdateDto.ThirdFooter;
		menuItem.UpdateDateTime = DateTime.Now;

		databaseContext.Update(menuItem);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
