namespace FRMJX.WebApi.Infrastructure.Dtos;

using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity;
using System.Collections.Generic;

/// <summary>
/// Authenticated User
/// </summary>
public class AuthenticatedUserDto
{
	/// <summary>
	/// User Name
	/// </summary>
	public string UserName { get; set; }

	/// <summary>
	/// EMail
	/// </summary>
	public string Email { get; set; }

	/// <summary>
	/// First Name
	/// </summary>
	public string FirstName { get; set; }

	/// <summary>
	/// Last Name
	/// </summary>
	public string LastName { get; set; }

	/// <summary>
	/// Phone Number
	/// </summary>
	public string PhoneNumber { get; set; }

	/// <summary>
	/// Access Level
	/// </summary>
	public AccessLevelEnum AccessLevel { get; set; }

	/// <summary>
	/// Security Claims
	/// </summary>
	public List<SecurityClaimDto> SecurityClaims { get; set; }

	internal bool IsAppResponsible => AccessLevel is AccessLevelEnum.SuperAdmin or AccessLevelEnum.Admin;
}
