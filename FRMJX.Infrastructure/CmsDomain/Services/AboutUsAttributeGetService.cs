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

internal class AboutUsAttributeGetService : IAboutUsAttributeGetService
{
	private readonly DatabaseContext databaseContext;

	public AboutUsAttributeGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<AboutUsAttributeGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<AboutUsAttributeGetResponseDto>();

		var aboutUsAttribute = await databaseContext.AboutUsAttributes
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (aboutUsAttribute != null)
		{
			serviceResult.Result = new AboutUsAttributeGetResponseDto
			{
				Id = aboutUsAttribute.Id,
				Ordering = aboutUsAttribute.Ordering,
				IsActive = aboutUsAttribute.IsActive,
				Title = aboutUsAttribute.Title,
				Description = aboutUsAttribute.Description,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<AboutUsAttributeGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<AboutUsAttributeGetResponseDto>>();

		var aboutUsAttributes = await databaseContext.AboutUsAttributes
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = aboutUsAttributes
			.Select(current => new AboutUsAttributeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<AboutUsAttributeGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<AboutUsAttributeGetResponseDto>>();

		var aboutUsAttributes = await databaseContext.AboutUsAttributes
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = aboutUsAttributes
			.Select(current => new AboutUsAttributeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
			})
			.ToList();

		return serviceResult;
	}
}
