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

internal class InsuranceGetService : IInsuranceGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public InsuranceGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<InsuranceGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<InsuranceGetResponseDto>();

		var insurance = await databaseContext.Insurances
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (insurance != null)
		{
			serviceResult.Result = new InsuranceGetResponseDto
			{
				Id = insurance.Id,
				Ordering = insurance.Ordering,
				IsActive = insurance.IsActive,
				Title = insurance.Title,
				Description = insurance.Description,
				ImageInfo = insurance.ImageId is not null ? customFileGetService.GetById((int)insurance.ImageId, CustomFileType.Image, cancellationToken).Result.Result : null,
				IconInfo = customFileGetService.GetById(insurance.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<InsuranceGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<InsuranceGetResponseDto>>();

		var insurances = await databaseContext.Insurances
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = insurances
			.Select(current => new InsuranceGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				ImageInfo = current.ImageId is not null ? customFileGetService.GetById((int)current.ImageId, CustomFileType.Image, cancellationToken).Result.Result : null,
				IconInfo = customFileGetService.GetById(current.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<InsuranceGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken, string? title = null)
	{
		var serviceResult = new ServiceResult<List<InsuranceGetResponseDto>>();

		var query = databaseContext.Insurances
			.Where(current => current.CultureLcid == cultureLcid);

		if (!string.IsNullOrWhiteSpace(title))
		{
			title = title.Trim().ToLower();
			query = query.Where(x => x.Title.ToLower().Contains(title));
		}

		var insurances = await query.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = insurances
			.Select(current => new InsuranceGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				ImageInfo = current.ImageId is not null ? customFileGetService.GetById((int)current.ImageId, CustomFileType.Image, cancellationToken).Result.Result : null,
				IconInfo = customFileGetService.GetById(current.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
