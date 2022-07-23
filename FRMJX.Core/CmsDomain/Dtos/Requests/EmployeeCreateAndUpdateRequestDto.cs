namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class EmployeeCreateAndUpdateRequestDto
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string? UserName { get; set; }

	public string? Password { get; set; }

	public string Email { get; set; }

	public string MobileNumber { get; set; }

	public string Position { get; set; }

	public string? Gender { get; set; }

	public int? Age { get; set; }

	public string? NationalCode { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int CustomFileId { get; set; }

	public int JobPositionId { get; set; }
}
