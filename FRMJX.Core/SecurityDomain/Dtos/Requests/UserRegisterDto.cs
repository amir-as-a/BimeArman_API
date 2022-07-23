namespace FRMJX.Core.SecurityDomain.Dtos.Requests;

public class UserRegisterDto
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string PhoneNumber { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public string Email { get; set; }

	public int AccessLevel { get; set; }
}
