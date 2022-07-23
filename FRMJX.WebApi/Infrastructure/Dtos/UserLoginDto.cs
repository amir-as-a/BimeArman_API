namespace FRMJX.WebApi.Infrastructure.Dtos;

public class UserLoginDto
{
	/// <summary>
	/// Username or Email
	/// </summary>
	public string UserName { get; set; }

	public string Password { get; set; }
}
