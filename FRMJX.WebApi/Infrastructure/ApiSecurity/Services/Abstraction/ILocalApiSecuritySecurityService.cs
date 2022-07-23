namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;

using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Local Api security claim management local service
/// </summary>
internal interface ILocalApiSecuritySecurityService
{
	/// <summary>
	/// Check user access to claim
	/// </summary>
	/// <param name="maximumAccessLevel">Maximum acceptable access level</param>
	/// <param name="userName">User Name</param>
	/// <param name="requiredClaims">Required claims values</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	Task<bool> CheckUserAccessBasedOnClaims(AccessLevelEnum maximumAccessLevel, string userName, SecurityClaimEnum[] requiredClaims);

	/// <summary>
	/// Get claims with dependencies
	/// </summary>
	/// <param name="claimEnums">Claim enum</param>
	/// <returns>Claims with dependencies</returns>
	List<SecurityClaimEnum> GetClaimsWithDependencies(List<SecurityClaimEnum> claimEnums);
}
