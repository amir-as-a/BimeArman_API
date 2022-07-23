namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using FRMJX.Infrastructure.BasicDataDomain.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class VendoringGetService : IVendoringGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly IStateGetService stateGetService;
	private readonly ICityGetService cityGetService;

	public VendoringGetService(DatabaseContext databaseContext, IStateGetService stateGetService, ICityGetService cityGetService)
	{
		this.databaseContext = databaseContext;
		this.stateGetService = stateGetService;
		this.cityGetService = cityGetService;
	}

	public async Task<ServiceResult<VendoringGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<VendoringGetResponseDto>();

		var vendoring = await databaseContext.Vendorings
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (vendoring != null)
		{
			serviceResult.Result = new VendoringGetResponseDto
			{
				Id = vendoring.Id,
				Ordering = vendoring.Ordering,
				IsActive = vendoring.IsActive,
				CityId = vendoring.CityId,
				StateId = vendoring.StateId,
				BirthDay = vendoring.BirthDay,
				DegreeOfEducation = vendoring.DegreeOfEducation,
				Description = vendoring.Description,
				FatherName = vendoring.FatherName,
				FieldOfStudy = vendoring.FieldOfStudy,
				FirstName = vendoring.FirstName,
				Gender = vendoring.Gender,
				LastName = vendoring.LastName,
				MilitaryService = vendoring.MilitaryService,
				MobileNumber = vendoring.MobileNumber,
				NationalCode = vendoring.NationalCode,
				WorkExperience = vendoring.WorkExperience,
				StateInfo = stateGetService.GetById(vendoring.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(vendoring.CityId, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<VendoringGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<VendoringGetResponseDto>>();

		var vendorings = await databaseContext.Vendorings
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = vendorings
			.Select(current => new VendoringGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				CityId = current.CityId,
				StateId = current.StateId,
				BirthDay = current.BirthDay,
				DegreeOfEducation = current.DegreeOfEducation,
				Description = current.Description,
				FatherName = current.FatherName,
				FieldOfStudy = current.FieldOfStudy,
				FirstName = current.FirstName,
				Gender = current.Gender,
				LastName = current.LastName,
				MilitaryService = current.MilitaryService,
				MobileNumber = current.MobileNumber,
				NationalCode = current.NationalCode,
				WorkExperience = current.WorkExperience,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<VendoringGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<VendoringGetResponseDto>>();

		var vendorings = await databaseContext.Vendorings
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = vendorings
			.Select(current => new VendoringGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				CityId = current.CityId,
				StateId = current.StateId,
				BirthDay = current.BirthDay,
				DegreeOfEducation = current.DegreeOfEducation,
				Description = current.Description,
				FatherName = current.FatherName,
				FieldOfStudy = current.FieldOfStudy,
				FirstName = current.FirstName,
				Gender = current.Gender,
				LastName = current.LastName,
				MilitaryService = current.MilitaryService,
				MobileNumber = current.MobileNumber,
				NationalCode = current.NationalCode,
				WorkExperience = current.WorkExperience,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<VendoringGetResponseDto>>> GetByState(int stateId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<VendoringGetResponseDto>>();

		var vendorings = await databaseContext.Vendorings
			.Where(current => current.StateId == stateId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = vendorings
			.Select(current => new VendoringGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				CityId = current.CityId,
				StateId = current.StateId,
				BirthDay = current.BirthDay,
				DegreeOfEducation = current.DegreeOfEducation,
				Description = current.Description,
				FatherName = current.FatherName,
				FieldOfStudy = current.FieldOfStudy,
				FirstName = current.FirstName,
				Gender = current.Gender,
				LastName = current.LastName,
				MilitaryService = current.MilitaryService,
				MobileNumber = current.MobileNumber,
				NationalCode = current.NationalCode,
				WorkExperience = current.WorkExperience,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<VendoringGetResponseDto>>> GetByCity(int cityId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<VendoringGetResponseDto>>();

		var vendorings = await databaseContext.Vendorings
			.Where(current => current.CityId == cityId)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = vendorings
			.Select(current => new VendoringGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				CityId = current.CityId,
				StateId = current.StateId,
				BirthDay = current.BirthDay,
				DegreeOfEducation = current.DegreeOfEducation,
				Description = current.Description,
				FatherName = current.FatherName,
				FieldOfStudy = current.FieldOfStudy,
				FirstName = current.FirstName,
				Gender = current.Gender,
				LastName = current.LastName,
				MilitaryService = current.MilitaryService,
				MobileNumber = current.MobileNumber,
				NationalCode = current.NationalCode,
				WorkExperience = current.WorkExperience,
				StateInfo = stateGetService.GetById(current.StateId, cancellationToken).Result.Result,
				CityInfo = cityGetService.GetById(current.CityId, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
