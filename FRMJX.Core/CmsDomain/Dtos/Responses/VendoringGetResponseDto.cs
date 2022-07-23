namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;

public class VendoringGetResponseDto
{
	public int Id { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string FatherName { get; set; }

	public string Gender { get; set; }

	public DateTime BirthDay { get; set; }

	public string NationalCode { get; set; }

	public string MobileNumber { get; set; }

	public string DegreeOfEducation { get; set; }

	public string FieldOfStudy { get; set; }

	public string MilitaryService { get; set; }

	public int StateId { get; set; }

	public int CityId { get; set; }

	public string Description { get; set; }

	public bool WorkExperience { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public StateGetResponseDto StateInfo { get; set; }

	public CityGetResponseDto CityInfo { get; set; }
}
