namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class VendoringCreateService : IVendoringCreateService
{
	private readonly DatabaseContext databaseContext;

	public VendoringCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		VendoringCreateAndUpdateRequestDto vendoringCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var vendoring = new Vendoring
		{
			CultureLcid = vendoringCreateAndUpdateDto.CultureLcid,
			IsActive = vendoringCreateAndUpdateDto.IsActive,
			Ordering = vendoringCreateAndUpdateDto.Ordering,
			CityId = vendoringCreateAndUpdateDto.CityId,
			StateId = vendoringCreateAndUpdateDto.StateId,
			BirthDay = vendoringCreateAndUpdateDto.BirthDay,
			DegreeOfEducation = vendoringCreateAndUpdateDto.DegreeOfEducation,
			Description = vendoringCreateAndUpdateDto.Description,
			FatherName = vendoringCreateAndUpdateDto.FatherName,
			FieldOfStudy = vendoringCreateAndUpdateDto.FieldOfStudy,
			FirstName = vendoringCreateAndUpdateDto.FirstName,
			Gender = vendoringCreateAndUpdateDto.Gender,
			LastName = vendoringCreateAndUpdateDto.LastName,
			MilitaryService = vendoringCreateAndUpdateDto.MilitaryService,
			MobileNumber = vendoringCreateAndUpdateDto.MobileNumber,
			NationalCode = vendoringCreateAndUpdateDto.NationalCode,
			WorkExperience = vendoringCreateAndUpdateDto.WorkExperience,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Vendorings.Add(vendoring);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = vendoring.Id;

		return serviceResult;
	}
}
