namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;

using System.Collections.Generic;

/// <summary>
/// Local Api security claim utility service
/// </summary>
public interface ILocalApiSecurityClaimUtilityService
{
	/// <summary>
	/// Validate given claim values
	/// </summary>
	/// <param name="claimValues">Claim values</param>
	/// <returns>Claims with type and validation result</returns>
	(bool Result, List<(string Type, string Value)>? Claims) ValidateClaims(List<string> claimValues);
}
