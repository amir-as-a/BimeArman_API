namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.BaseDataDomain.Services;
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

internal class HealthCenterPdfGetService : IHealthCenterPdfGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IStateGetService stateGetService;
	private readonly ICustomFileGetService customFileGetService;

	public HealthCenterPdfGetService(DatabaseContext databaseContext,
		IStateGetService stateGetService,
		ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.stateGetService = stateGetService;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<HealthCenterPdfGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<HealthCenterPdfGetResponseDto>();

		var healthCenterPdf = await databaseContext.HealthCenterPdfs
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (healthCenterPdf != null)
		{
			serviceResult.Result = new HealthCenterPdfGetResponseDto
			{
				Id = healthCenterPdf.Id,
				Ordering = healthCenterPdf.Ordering,
				IsActive = healthCenterPdf.IsActive,
				Title = healthCenterPdf.Title,
				CustomFileId = healthCenterPdf.CustomFileId,
				StateId = healthCenterPdf.StateId,
				CustomFileGetResponseDto = customFileGetService.GetById(healthCenterPdf.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				StateGetResponseDto = stateGetService.GetById(healthCenterPdf.StateId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<HealthCenterPdfGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<HealthCenterPdfGetResponseDto>>();

		var healthCenterPdfs = await databaseContext.HealthCenterPdfs
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = healthCenterPdfs
			.Select(current => new HealthCenterPdfGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomFileId = current.CustomFileId,
				StateId = current.StateId,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				StateGetResponseDto = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<HealthCenterPdfGetResponseDto>>> GetAll(int cultureLcid, int? stateId, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<HealthCenterPdfGetResponseDto>>();

		var query = databaseContext.HealthCenterPdfs
			.Where(current => current.CultureLcid == cultureLcid)
			;

		var helthCenters = await query.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = helthCenters
			.Select(current => new HealthCenterPdfGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomFileId = current.CustomFileId,
				StateId = current.StateId,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				StateGetResponseDto = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<HealthCenterPdfGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<HealthCenterPdfGetResponseDto>>();

		var healthCenterPdfs = await databaseContext.HealthCenterPdfs
			.Where(current => current.StateId == stateId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = healthCenterPdfs
			.Select(current => new HealthCenterPdfGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				CustomFileId = current.CustomFileId,
				StateId = current.StateId,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				StateGetResponseDto = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
