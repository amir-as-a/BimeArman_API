namespace FRMJX.Core.SecurityDomain.Models;

using FRMJX.Core.SecurityDomain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class User : IdentityUser<int>
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public AccessLevelEnum AccessLevel { get; set; }

	public bool IsAppResponsible => AccessLevel is AccessLevelEnum.SuperAdmin or AccessLevelEnum.Admin;

	public bool IsActive { get; set; }

	public bool IsDeleted { get; set; }
}
