namespace FRMJX.Core.WebServiceDomain.Dtos.Requests;

public class JoinusRequestDto
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public int GenderId { get; set; }

	public string? FatherName { get; set; }

	public string? NationalCode { get; set; }

	public string? IdentificationCardNumber { get; set; }

	public int BirthProvinceId { get; set; }

	public int BirthCityId { get; set; }

	public int ResidenceCityId { get; set; }

	public int ResidenceProvinceId { get; set; }

	public DateTime BirthDate { get; set; }

	public int MarriageStatusId { get; set; }

	public string PhoneNumber { get; set; }

	public string? HomeNumber { get; set; }

	public string EmailAdsress { get; set; }

	public string? Address { get; set; }

	public List<EducationJoinusRequestDto> Educations { get; set; }

	public List<SkillJoinusRequestDto> Skills { get; set; }

	public List<JobHistoryJoinusRequestDto> JobsHistory { get; set; }

	public List<JobJoinusRequestDto> JobList { get; set; }

	public ResumeJoinusRequestDto OfficialResume { get; set; }
}
