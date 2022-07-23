namespace FRMJX.Core.WebServiceDomain.Dtos.Requests;

public class AgencyRequestDto
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string FatherName { get; set; }

	public string Gender { get; set; }

	public DateTime BirthDate { get; set; }

	public string NationalCode { get; set; }

	public string PhoneNumber { get; set; }

	public string EducationLevel { get; set; }

	public string EducationField { get; set; }

	public string NezamVazifeStatus { get; set; }

	public string Province { get; set; }

	public string City { get; set; }

	public bool HasWorkHistoryOnInsuranceCompanies { get; set; }

	public string Description { get; set; }
}
