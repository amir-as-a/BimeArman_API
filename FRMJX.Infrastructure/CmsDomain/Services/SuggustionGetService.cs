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

internal class SuggustionGetService : ISuggustionGetService
{
	private readonly DatabaseContext databaseContext;

	public SuggustionGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<SuggustionGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<SuggustionGetResponseDto>();

		var suggustion = await databaseContext.Suggustions
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (suggustion != null)
		{
			serviceResult.Result = new SuggustionGetResponseDto
			{
				Id = suggustion.Id,
				Ordering = suggustion.Ordering,
				IsActive = suggustion.IsActive,
				FullName = suggustion.FullName,
				MobileNumber = suggustion.MobileNumber,
				Text = suggustion.Text,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<SuggustionGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SuggustionGetResponseDto>>();

		var suggustions = await databaseContext.Suggustions
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = suggustions
			.Select(current => new SuggustionGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				FullName = current.FullName,
				MobileNumber = current.MobileNumber,
				Text = current.Text,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<SuggustionGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SuggustionGetResponseDto>>();

		var suggustions = await databaseContext.Suggustions
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = suggustions
			.Select(current => new SuggustionGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				FullName = current.FullName,
				MobileNumber = current.MobileNumber,
				Text = current.Text,
			})
			.ToList();

		return serviceResult;
	}
}
