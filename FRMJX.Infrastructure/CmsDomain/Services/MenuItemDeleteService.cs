namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class MenuItemDeleteService : IMenuItemDeleteService
{
	private readonly DatabaseContext databaseContext;

	public MenuItemDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var menuItem = databaseContext.MenuItems
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (menuItem is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(menuItem);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
