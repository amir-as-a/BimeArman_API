namespace FRMJX.WebApi.Infrastructure.Services.Abstraction;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.WebApi.Infrastructure.Dtos;
using FRMJX.WebApi.Infrastructure.Helpers;
using System.Security.Claims;
using System.Threading.Tasks;

/// <summary>
/// Local Auth service
/// </summary>
public interface ILocalAuthService
{
	/// <summary>
	/// Generate Token
	/// </summary>
	/// <param name="user">User</param>
	/// <param name="jwtSettings">JWT Setting</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	Task<TokensDto> GenerateTokens(User user, JwtSettings jwtSettings);

	/// <summary>
	/// Get principal from expired token
	/// </summary>
	/// <param name="token">Token</param>
	/// <param name="jwtSettings">JWT Setting</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	ClaimsPrincipal GetPrincipalFromExpiredToken(string token, JwtSettings jwtSettings);

	/// <summary>
	/// Delete Token By UserId
	/// </summary>
	/// <param name="userId">user Id</param>
	/// <returns>nothing</returns>
	ServiceResult DeleteTokens(int userId);
}
