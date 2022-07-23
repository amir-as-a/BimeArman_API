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

internal class RevelationGetService : IRevelationGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public RevelationGetService(DatabaseContext databaseContext,
		ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<RevelationGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<RevelationGetResponseDto>();

		var revelation = await databaseContext.Revelations
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (revelation != null)
		{
			serviceResult.Result = new RevelationGetResponseDto
			{
				Id = revelation.Id,
				CustomeFileId = revelation.CustomeFileId,
				CustomFileGetResponseDto = customFileGetService.GetById(revelation.CustomeFileId, CustomFileType.File, cancellationToken).Result.Result,
				Ordering = revelation.Ordering,
				IsActive = revelation.IsActive,
				Title = revelation.Title,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<RevelationGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RevelationGetResponseDto>>();

		var revelations = await databaseContext.Revelations
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = revelations
			.Select(current => new RevelationGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomeFileId = current.CustomeFileId,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomeFileId , CustomFileType.File , cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<RevelationGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RevelationGetResponseDto>>();

		var revelations = await databaseContext.Revelations
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = revelations
			.Select(current => new RevelationGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomeFileId = current.CustomeFileId,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomeFileId, CustomFileType.File, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
