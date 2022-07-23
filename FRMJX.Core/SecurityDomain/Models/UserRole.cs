namespace FRMJX.Core.SecurityDomain.Models;
using Microsoft.AspNetCore.Identity;

public class UserRole : IdentityUserRole<int>
{
	public Role Role { get; set; }
}
