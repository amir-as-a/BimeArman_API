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

internal class EmployeeGetService : IEmployeeGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;
	private readonly IJobPositionGetService jobPositionGetService;

	public EmployeeGetService(DatabaseContext databaseContext,
		ICustomFileGetService customFileGetService,
		IJobPositionGetService jobPositionGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
		this.jobPositionGetService = jobPositionGetService;
	}

	public async Task<ServiceResult<EmployeeGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<EmployeeGetResponseDto>();

		var employee = await databaseContext.Employees
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (employee != null)
		{
			serviceResult.Result = new EmployeeGetResponseDto
			{
				Id = employee.Id,
				Ordering = employee.Ordering,
				IsActive = employee.IsActive,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				UserName = employee.UserName,
				Email = employee.Email,
				MobileNumber = employee.MobileNumber,
				Position = employee.Position,
				Age = employee.Age,
				Gender = employee.Gender,
				PositionId = employee.JobPositionId,
				NationalCode = employee.NationalCode,
				CustomFileGetResponseDto = customFileGetService.GetById(employee.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				JobPositionGetResponseDto = jobPositionGetService.GetById(employee.JobPositionId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<EmployeeGetResponseDto>>> GetByNationalCode(string nationalCode, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<EmployeeGetResponseDto>>();

		var employees = await databaseContext.Employees
			.Where(current => nationalCode == current.NationalCode)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = employees
			.Select(current => new EmployeeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				FirstName = current.FirstName,
				LastName = current.LastName,
				UserName = current.UserName,
				Email = current.Email,
				MobileNumber = current.MobileNumber,
				Position = current.Position,
				Age = current.Age,
				Gender = current.Gender,
				PositionId = current.JobPositionId,
				NationalCode = current.NationalCode,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				JobPositionGetResponseDto = jobPositionGetService.GetById(current.JobPositionId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<EmployeeGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<EmployeeGetResponseDto>>();

		var employees = await databaseContext.Employees
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = employees
			.Select(current => new EmployeeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				FirstName = current.FirstName,
				LastName = current.LastName,
				UserName = current.UserName,
				Email = current.Email,
				MobileNumber = current.MobileNumber,
				Position = current.Position,
				Age = current.Age,
				Gender = current.Gender,
				PositionId = current.JobPositionId,
				NationalCode = current.NationalCode,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				JobPositionGetResponseDto = jobPositionGetService.GetById(current.JobPositionId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<EmployeeGetResponseDto>>> GetAll(int cultureLcid, int? positionId, string? nationalCode, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<EmployeeGetResponseDto>>();

		var query = databaseContext.Employees
			.Where(current => current.CultureLcid == cultureLcid);

		if (positionId != null)
		{
			query = query.Where(x => x.JobPositionId == positionId);
		}

		if (!string.IsNullOrEmpty(nationalCode))
		{
			query = query.Where(x => x.NationalCode == nationalCode);
		}

		var employees = await query.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = employees
			.Select(current => new EmployeeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				FirstName = current.FirstName,
				LastName = current.LastName,
				UserName = current.UserName,
				Email = current.Email,
				MobileNumber = current.MobileNumber,
				PositionId = current.JobPositionId,
				Position = current.Position,
				Age = current.Age,
				Gender = current.Gender,
				NationalCode = current.NationalCode,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				JobPositionGetResponseDto = jobPositionGetService.GetById(current.JobPositionId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<EmployeeGetResponseDto>>> GetByPositionId(int positionId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<EmployeeGetResponseDto>>();

		var employees = await databaseContext.Employees
			.Where(current => current.JobPositionId == positionId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = employees
			.Select(current => new EmployeeGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				FirstName = current.FirstName,
				LastName = current.LastName,
				UserName = current.UserName,
				Email = current.Email,
				MobileNumber = current.MobileNumber,
				Position = current.Position,
				PositionId = current.JobPositionId,
				Age = current.Age,
				Gender = current.Gender,
				NationalCode = current.NationalCode,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.Image, cancellationToken).Result.Result,
				JobPositionGetResponseDto = jobPositionGetService.GetById(current.JobPositionId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
