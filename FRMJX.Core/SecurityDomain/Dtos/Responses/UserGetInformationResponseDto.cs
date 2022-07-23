namespace FRMJX.Core.SecurityDomain.Dtos.Responses;

using FRMJX.Core.SecurityDomain.Enums;
using System.Collections.Generic;
using System.Security.Claims;

public class UserGetInformationResponseDto
{
	public int Id { get; set; }

	public string UserName { get; set; }

	public string Email { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string PhoneNumber { get; set; }

	public AccessLevelEnum AccessLevel { get; set; }

	public IEnumerable<Claim> Claims { get; set; }
}
