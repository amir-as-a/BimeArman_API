namespace FRMJX.Core.SecurityDomain.Dtos.Responses;

using System;
using System.Collections.Generic;

public class RoleGetDetailResponseDto
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public List<string> SecurityClaims { get; set; }
}
