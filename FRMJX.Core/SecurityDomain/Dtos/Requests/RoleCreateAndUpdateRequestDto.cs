namespace FRMJX.Core.SecurityDomain.Dtos.Requests;

using System.Collections.Generic;

public class RoleCreateAndUpdateRequestDto
{
	public string Name { get; set; }

	public string Description { get; set; }

	public List<string> SecurityClaims { get; set; }
}
