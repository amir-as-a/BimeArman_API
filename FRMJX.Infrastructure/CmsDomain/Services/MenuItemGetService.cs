namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class MenuItemGetService : IMenuItemGetService
{
	private readonly DatabaseContext databaseContext;

	public MenuItemGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<MenuItemGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<MenuItemGetResponseDto>();

		var menuItem = await databaseContext.MenuItems
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItem != null)
		{
			serviceResult.Result = new MenuItemGetResponseDto
			{
				Id = menuItem.Id,
				Ordering = menuItem.Ordering,
				IsActive = menuItem.IsActive,
				ParentId = menuItem.ParentId,
				Title = menuItem.Title,
				Url = menuItem.Url,
				FirstFooter = menuItem.FirstFooter,
				SecendFooter = menuItem.SecendFooter,
				ThirdFooter = menuItem.ThirdFooter,
				OpenInNewTab = menuItem.OpenInNewTab,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<MenuItemGetResponseDto>>> GetActivesByParentId(int cultureLcid, int? parentId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<MenuItemGetResponseDto>>();

		var menuItems = await databaseContext.MenuItems
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.Where(current => current.ParentId == parentId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = menuItems
			.Select(current => new MenuItemGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				ParentId = current.ParentId,
				IsActive = current.IsActive,
				Title = current.Title,
				Url = current.Url,
				FirstFooter = current.FirstFooter,
				SecendFooter = current.SecendFooter,
				ThirdFooter = current.ThirdFooter,
				OpenInNewTab = current.OpenInNewTab,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<MenuItemGetResponseDto>>> GetActives(int cultureLcid, CancellationToken cancellationToken, int? parentId = null)
	{
		var serviceResult = new ServiceResult<List<MenuItemGetResponseDto>>();

		var query = databaseContext.MenuItems
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive);

		if (parentId.HasValue)
		{
			query = query.Where(current => current.ParentId == parentId);
		}
		else
		{
			query = query.Where(current => current.ParentId == null);
		}

		var menuItems = await query
			.Include(current => current.Childeren)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = menuItems
			.Select(current => new MenuItemGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				ParentId = current.ParentId,
				IsActive = current.IsActive,
				Title = current.Title,
				Url = current.Url,
				FirstFooter = current.FirstFooter,
				SecendFooter = current.SecendFooter,
				ThirdFooter = current.ThirdFooter,
				OpenInNewTab = current.OpenInNewTab,
				Children = current.Childeren.Count > 0 ? GetAll(cultureLcid, cancellationToken, current.Id).Result.Result : new List<MenuItemGetResponseDto>(),
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<MenuItemGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken, int? parentId = null)
	{
		var serviceResult = new ServiceResult<List<MenuItemGetResponseDto>>();

		var query = databaseContext.MenuItems
			.Where(current => current.CultureLcid == cultureLcid)
			;

		if (parentId.HasValue)
		{
			query = query.Where(current => current.ParentId == parentId);
		}
		else
		{
			query = query.Where(current => current.ParentId == null);
		}

		var menuItems = await query
			.Include(current => current.Childeren)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = menuItems
			.Select(current => new MenuItemGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				ParentId = current.ParentId,
				IsActive = current.IsActive,
				Title = current.Title,
				Url = current.Url,
				FirstFooter = current.FirstFooter,
				SecendFooter = current.SecendFooter,
				ThirdFooter = current.ThirdFooter,
				OpenInNewTab = current.OpenInNewTab,
				Children = current.Childeren.Count > 0 ? GetAll(cultureLcid, cancellationToken, current.Id).Result.Result : new List<MenuItemGetResponseDto>(),
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<MenuItemGetResponseDto>>> GetByParentId(int cultureLcid, int? parentId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<MenuItemGetResponseDto>>();

		var menuItems = await databaseContext.MenuItems
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.ParentId == parentId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = menuItems
			.Select(current => new MenuItemGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ParentId = current.ParentId,
				Title = current.Title,
				Url = current.Url,
				FirstFooter = current.FirstFooter,
				SecendFooter = current.SecendFooter,
				ThirdFooter = current.ThirdFooter,
				OpenInNewTab = current.OpenInNewTab,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<MenuItemGetResponseDto>>> GetMenuItem(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<MenuItemGetResponseDto>>();

		var menuItems = await databaseContext.MenuItems
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.FirstFooter == false && current.SecendFooter == false && current.ThirdFooter == false && current.IsActive == true)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = menuItems
			.Select(current => new MenuItemGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ParentId = current.ParentId,
				Title = current.Title,
				Url = current.Url,
				FirstFooter = current.FirstFooter,
				SecendFooter = current.SecendFooter,
				ThirdFooter = current.ThirdFooter,
				OpenInNewTab = current.OpenInNewTab,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<MenuItemGetResponseDto>>> GetFirstFooter(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<MenuItemGetResponseDto>>();

		var menuItems = await databaseContext.MenuItems
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.FirstFooter == true && current.IsActive == true)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = menuItems
			.Select(current => new MenuItemGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ParentId = current.ParentId,
				Title = current.Title,
				Url = current.Url,
				FirstFooter = current.FirstFooter,
				SecendFooter = current.SecendFooter,
				ThirdFooter = current.ThirdFooter,
				OpenInNewTab = current.OpenInNewTab,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<MenuItemGetResponseDto>>> GetSecendFooter(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<MenuItemGetResponseDto>>();

		var menuItems = await databaseContext.MenuItems
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.SecendFooter == true && current.IsActive == true)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = menuItems
			.Select(current => new MenuItemGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ParentId = current.ParentId,
				Title = current.Title,
				Url = current.Url,
				FirstFooter = current.FirstFooter,
				SecendFooter = current.SecendFooter,
				ThirdFooter = current.ThirdFooter,
				OpenInNewTab = current.OpenInNewTab,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<MenuItemGetResponseDto>>> GetThirdFooter(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<MenuItemGetResponseDto>>();

		var menuItems = await databaseContext.MenuItems
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.ThirdFooter == true && current.IsActive == true)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = menuItems
			.Select(current => new MenuItemGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				ParentId = current.ParentId,
				Title = current.Title,
				Url = current.Url,
				FirstFooter = current.FirstFooter,
				SecendFooter = current.SecendFooter,
				ThirdFooter = current.ThirdFooter,
				OpenInNewTab = current.OpenInNewTab,
			})
			.ToList();

		return serviceResult;
	}
}
