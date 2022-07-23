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

internal class RegulationGetService : IRegulationGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public RegulationGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<RegulationGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<RegulationGetResponseDto>();

		var regulation = await databaseContext.Regulations
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (regulation != null)
		{
			serviceResult.Result = new RegulationGetResponseDto
			{
				Id = regulation.Id,
				Ordering = regulation.Ordering,
				IsActive = regulation.IsActive,
				Title = regulation.Title,
				CustomFileGetResponseDto = customFileGetService.GetById(regulation.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<RegulationGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RegulationGetResponseDto>>();

		var regulations = await databaseContext.Regulations
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = regulations
			.Select(current => new RegulationGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<RegulationGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<RegulationGetResponseDto>>();

		var regulations = await databaseContext.Regulations
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = regulations
			.Select(current => new RegulationGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
