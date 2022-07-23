namespace FRMJX.WebApi.Infrastructure.Services.Implementation;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Infrastructure;
using FRMJX.WebApi.Infrastructure.Dtos;
using FRMJX.WebApi.Infrastructure.Helpers;
using FRMJX.WebApi.Infrastructure.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

internal class LocalAuthService : ILocalAuthService
{
	private readonly UserManager<User> userManager;
	private readonly DatabaseContext databaseContext;


	public LocalAuthService(UserManager<User> userManager,
		DatabaseContext databaseContext)
	{
		this.userManager = userManager;
		this.databaseContext = databaseContext;
	}

	public async Task<TokensDto> GenerateTokens(User user, JwtSettings jwtSettings)
	{
		var userRoles = await userManager.GetRolesAsync(user);
		await userManager.RemoveAuthenticationTokenAsync(user, jwtSettings.LoginProvider, "RefreshToken");

		await userManager.UpdateSecurityStampAsync(user);

		string GenerateAccessToken(User user, IList<string> roles, JwtSettings jwtSettings)
		{
			var tokenClaims = new List<Claim>
				{
					new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				};

			tokenClaims.AddRange(roles.Select(current => new Claim(ClaimTypes.Role, current)));

			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
			var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

			var encryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.EncryptionKey));
			var encryptingCredentials = new EncryptingCredentials(encryptionKey, SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

			var issuedAt = DateTime.UtcNow;
			var expires = issuedAt.AddSeconds(Convert.ToDouble(jwtSettings.AccessTokenExpirationInSeconds));

			var securityTokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = jwtSettings.Issuer,
				Audience = jwtSettings.Audience,
				IssuedAt = issuedAt,
				Expires = expires,
				SigningCredentials = signingCredentials,
				EncryptingCredentials = encryptingCredentials,
				Subject = new ClaimsIdentity(tokenClaims),
			};

			var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
			var encryptedToken = jwtSecurityTokenHandler.WriteToken(securityToken);

			return encryptedToken;
		}

		var accessToken = GenerateAccessToken(user, userRoles, jwtSettings);

		var refreshToken = await userManager.GenerateUserTokenAsync(user, jwtSettings.LoginProvider, jwtSettings.RefreshTokenTitle);
		await userManager.SetAuthenticationTokenAsync(user, jwtSettings.LoginProvider, jwtSettings.RefreshTokenTitle, refreshToken);

		return new TokensDto
		{
			AccessToken = new TokenDto { Token = accessToken, ExpiresInSeconds = jwtSettings.AccessTokenExpirationInSeconds },
			RefreshToken = new TokenDto { Token = refreshToken, ExpiresInSeconds = jwtSettings.RefreshTokenExpirationInSeconds },
		};
	}

	public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, JwtSettings jwtSettings)
	{
		var tokenValidationParameters = new TokenValidationParameters
		{
			ValidateAudience = true,
			ValidAudience = jwtSettings.Issuer,
			ValidateIssuer = true,
			ValidIssuer = jwtSettings.Issuer,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
			TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.EncryptionKey)),
			ValidateLifetime = false, // here we are saying that we don't care about the token's expiration date
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

		var isTokenValid = false;
		if (securityToken is JwtSecurityToken jwtSecurityToken)
		{
			isTokenValid = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.Aes128KW, StringComparison.InvariantCultureIgnoreCase);
		}

		return isTokenValid
			? principal
			: throw new SecurityTokenException("Invalid token");
	}

	public ServiceResult DeleteTokens(int userId)
	{
		var serviceResult = new ServiceResult();

		var token = databaseContext.UserTokens
			.Where(current => current.UserId == userId)
			.SingleOrDefault();

		if (token is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(token);
		databaseContext.SaveChanges();

		return serviceResult;
	}
}
