namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class VendoringUpdateService : IVendoringUpdateService
{
	private readonly DatabaseContext databaseContext;

	public VendoringUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		VendoringCreateAndUpdateRequestDto vendoringCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var vendoring = await databaseContext.Vendorings
			.SingleOrDefaultAsync(current => current.Id == id);

		if (vendoring is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Vendoring not found");
			return serviceResult;
		}

		vendoring.CityId = vendoringCreateAndUpdateDto.CityId;
		vendoring.StateId = vendoringCreateAndUpdateDto.StateId;
		vendoring.CultureLcid = vendoringCreateAndUpdateDto.CultureLcid;
		vendoring.Ordering = vendoringCreateAndUpdateDto.Ordering;
		vendoring.IsActive = vendoringCreateAndUpdateDto.IsActive;
		vendoring.BirthDay = vendoringCreateAndUpdateDto.BirthDay;
		vendoring.DegreeOfEducation = vendoringCreateAndUpdateDto.DegreeOfEducation;
		vendoring.Description = vendoringCreateAndUpdateDto.Description;
		vendoring.FatherName = vendoringCreateAndUpdateDto.FatherName;
		vendoring.FieldOfStudy = vendoringCreateAndUpdateDto.FieldOfStudy;
		vendoring.FirstName = vendoringCreateAndUpdateDto.FirstName;
		vendoring.Gender = vendoringCreateAndUpdateDto.Gender;
		vendoring.LastName = vendoringCreateAndUpdateDto.LastName;
		vendoring.MilitaryService = vendoringCreateAndUpdateDto.MilitaryService;
		vendoring.MobileNumber = vendoringCreateAndUpdateDto.MobileNumber;
		vendoring.NationalCode = vendoringCreateAndUpdateDto.NationalCode;
		vendoring.WorkExperience = vendoringCreateAndUpdateDto.WorkExperience;
		vendoring.UpdateDateTime = DateTime.Now;

		databaseContext.Update(vendoring);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
