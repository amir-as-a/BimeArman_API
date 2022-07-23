namespace FRMJX.WebApi.Infrastructure.ApiSecurity;

using System.Collections.Generic;

/// <summary>
/// Claim dto
/// </summary>
public class SecurityClaimDto
{
	/// <summary>
	/// Claim Value
	/// </summary>
	public string Value { get; set; }

	/// <summary>
	/// Claim dependencies
	/// </summary>
	public List<string> Dependencies { get; set; }
}
