namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class RevelationAttributeGetService : IRevelationAttributeGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IRevelationGetService revelationGetService;
	private readonly ICustomFileGetService customFileGetService;

	public RevelationAttributeGetService(DatabaseContext databaseContext,
		IRevelationGetService revelationGetService,
		ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.revelationGetService = revelationGetService;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<RevelationAttributeGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<RevelationAttributeGetResponseDto>();

		var revelationAttribute = await databaseContext.RevelationAttributes
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (revelationAttribute != null)
		{
			serviceResult.Result = new RevelationAttributeGetResponseDto
			{
				Id = revelationAttribute.Id,
				Ordering = revelationAttribute.Ordering,
				IsActive = revelationAttribute.IsActive,
				Title = revelationAttribute.Title,
				CustomFileId = revelationAttribute.CustomFileId,
				CustomFileGetResponse = customFileGetService.GetById(revelationAttribute.CustomFileId, CustomFileType.File , cancellationToken).Result.Result,
				RevelationGetResponseDto = revelationGetService.GetById(revelationAttribute.RevelationId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<RevelationAttributeGetResponseDto>>> GetByRevelationId(int RevelationId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RevelationAttributeGetResponseDto>>();

		var revelationAttributes = await databaseContext.RevelationAttributes
			.Where(current => current.RevelationId == RevelationId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = revelationAttributes
			.Select(current => new RevelationAttributeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomFileId=current.CustomFileId,
				CustomFileGetResponse = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				RevelationGetResponseDto = revelationGetService.GetById(current.RevelationId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<RevelationAttributeGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RevelationAttributeGetResponseDto>>();

		var revelationAttributes = await databaseContext.RevelationAttributes
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = revelationAttributes
			.Select(current => new RevelationAttributeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomFileId = current.CustomFileId,
				CustomFileGetResponse = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				RevelationGetResponseDto = revelationGetService.GetById(current.RevelationId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<RevelationAttributeGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RevelationAttributeGetResponseDto>>();

		var revelationAttributes = await databaseContext.RevelationAttributes
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = revelationAttributes
			.Select(current => new RevelationAttributeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomFileId = current.CustomFileId,
				CustomFileGetResponse = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				RevelationGetResponseDto = revelationGetService.GetById(current.RevelationId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
