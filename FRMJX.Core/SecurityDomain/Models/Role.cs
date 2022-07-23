namespace FRMJX.Core.SecurityDomain.Models;

using Microsoft.AspNetCore.Identity;

public class Role : IdentityRole<int>
{
	public string Description { get; set; }

	public ICollection<UserRole> UserRoles { get; set; }
}
