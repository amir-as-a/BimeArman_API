namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;

using FRMJX.Core.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity;
using System.Collections.Generic;

/// <summary>
/// Local Api service claim management service
/// </summary>
public interface ILocalApiSecurityClaimManagementService
{
	/// <summary>
	/// Get claims list
	/// </summary>
	/// <returns>Claims</returns>
	ServiceResult<List<SecurityClaimDto>> GetSecurityClaims();
}
