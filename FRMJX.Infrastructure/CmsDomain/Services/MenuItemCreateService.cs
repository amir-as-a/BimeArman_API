namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class MenuItemCreateService : IMenuItemCreateService
{
	private readonly DatabaseContext databaseContext;

	public MenuItemCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		MenuItemCreateAndUpdateRequestDto menuItemCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var menuItem = new MenuItem
		{
			CultureLcid = menuItemCreateAndUpdateDto.CultureLcid,
			IsActive = menuItemCreateAndUpdateDto.IsActive,
			Ordering = menuItemCreateAndUpdateDto.Ordering,
			ParentId = menuItemCreateAndUpdateDto.ParentId,
			Title = menuItemCreateAndUpdateDto.Title,
			Url = menuItemCreateAndUpdateDto.Url,
			FirstFooter = menuItemCreateAndUpdateDto.FirstFooter,
			SecendFooter = menuItemCreateAndUpdateDto.SecendFooter,
			ThirdFooter = menuItemCreateAndUpdateDto.ThirdFooter,
			OpenInNewTab = menuItemCreateAndUpdateDto.OpenInNewTab,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.MenuItems.Add(menuItem);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = menuItem.Id;

		return serviceResult;
	}
}
