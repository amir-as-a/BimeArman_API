namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class EmployeeGetResponseDto
{
	public int Id { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string? UserName { get; set; }

	public string? Password { get; set; }

	public string Email { get; set; }

	public string MobileNumber { get; set; }

	public string Position { get; set; }

	public int? PositionId { get; set; }

	public string? Gender { get; set; }

	public int? Age { get; set; }

	public string? NationalCode { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public CustomFileGetResponseDto CustomFileGetResponseDto { get; set; }

	public JobPositionGetResponseDto JobPositionGetResponseDto { get; set; }
}
