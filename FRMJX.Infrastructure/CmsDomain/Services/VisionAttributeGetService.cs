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

internal class VisionAttributeGetService : IVisionAttributeGetService
{
	private readonly DatabaseContext databaseContext;

	public VisionAttributeGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<VisionAttributeGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<VisionAttributeGetResponseDto>();

		var visionAttribute = await databaseContext.VisionAttributes
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (visionAttribute != null)
		{
			serviceResult.Result = new VisionAttributeGetResponseDto
			{
				Id = visionAttribute.Id,
				Ordering = visionAttribute.Ordering,
				IsActive = visionAttribute.IsActive,
				Title = visionAttribute.Title,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<VisionAttributeGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<VisionAttributeGetResponseDto>>();

		var visionAttributes = await databaseContext.VisionAttributes
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = visionAttributes
			.Select(current => new VisionAttributeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<VisionAttributeGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<VisionAttributeGetResponseDto>>();

		var visionAttributes = await databaseContext.VisionAttributes
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = visionAttributes
			.Select(current => new VisionAttributeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
			})
			.ToList();

		return serviceResult;
	}
}
