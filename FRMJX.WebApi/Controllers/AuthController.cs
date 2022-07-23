namespace FRMJX.WebApi.Controllers;

using FRMJX.Core.SecurityDomain.Dtos.Requests;
using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.Dtos;
using FRMJX.WebApi.Infrastructure.Helpers;
using FRMJX.WebApi.Infrastructure.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Auth controller
/// </summary>
[Route("api/auth")]
[ApiExplorerSettings(GroupName = "Auth")]
public class AuthController : BaseController
{
	/// <summary>
	/// Sign in
	/// </summary>
	/// <param name="userManager">Automatically fetch from container</param>
	/// <param name="jwtSettings">Automatically fetch from container</param>
	/// <param name="localAuthService">Automatically fetch from container</param>
	/// <param name="userLoginDto">User login dto</param>
	/// <param name="cancellationToken">Cancellation Token</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[HttpPost("signin")]
	[AllowAnonymous]
	public async Task<IActionResult> SignIn(
		[FromServices] UserManager<User> userManager,
		[FromServices] IOptionsSnapshot<JwtSettings> jwtSettings,
		[FromServices] ILocalAuthService localAuthService,
		UserLoginDto userLoginDto,
		CancellationToken cancellationToken)
	{
		var user = await userManager.FindByNameAsync(userLoginDto.UserName);

		if (user is null)
		{
			user = await userManager.FindByEmailAsync(userLoginDto.UserName);

			if (user is null)
			{
				return NotFound("Email or password is incorrect");
			}
		}

		if (userManager.SupportsUserLockout && await userManager.IsLockedOutAsync(user))
		{
			return BadRequest("Account is locked out");
		}

		if (user.IsActive is false)
		{
			return BadRequest("Account is deactive");
		}

		var userSigninResult = await userManager.CheckPasswordAsync(user, userLoginDto.Password);

		if (userManager.SupportsUserLockout)
		{
			if (userSigninResult)
			{
				await userManager.ResetAccessFailedCountAsync(user);
			}
			else
			{
				await userManager.AccessFailedAsync(user);
			}
		}

		return userSigninResult == false
			? BadRequest("Email or password is incorrect")
			: Ok(await localAuthService.GenerateTokens(user, jwtSettings.Value));
	}

	/// <summary>
	/// Sign up
	/// </summary>
	/// <param name="userManager">Automatically fetch from container</param>
	/// <param name="userRegisterDto">User Regidter dto</param>
	/// <param name="cancellationToken">Cancellation Token</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	[HttpPost("signup")]
	[AllowAnonymous]
	public async Task<IActionResult> SignUp(
		[FromServices] UserManager<User> userManager,
		UserRegisterDto userRegisterDto,
		CancellationToken cancellationToken)
	{
		var user = await userManager.FindByNameAsync(userRegisterDto.UserName);
		if (user != null)
		{
			return BadRequest("username is already exist!");
		}

		user = await userManager.FindByNameAsync(userRegisterDto.UserName);
		if (user != null)
		{
			return BadRequest("email is already exist!");
		}

		if (userRegisterDto.Email == "string" || string.IsNullOrEmpty(userRegisterDto.Email))
		{
			userRegisterDto.Email = "example@mail.com";
		}

		user = new User
		{
			UserName = userRegisterDto.UserName,
			PhoneNumber = userRegisterDto.PhoneNumber,
			FirstName = userRegisterDto.FirstName,
			LastName = userRegisterDto.LastName,
			Email = userRegisterDto.Email,
			IsActive = true,
			IsDeleted = false,
			AccessLevel = (AccessLevelEnum)Enum.ToObject(typeof(AccessLevelEnum), userRegisterDto.AccessLevel),
		};

		var userSignupResult = await userManager.CreateAsync(user, userRegisterDto.Password);

		var errors = string.Empty;
		for (var i = 0; i < userSignupResult.Errors.Count(); i++)
		{
			errors += $"{i + 1}-{userSignupResult.Errors.ElementAt(i).Description?.ToString()} ";
		}

		return userSignupResult.Succeeded == false
			? BadRequest(errors)
			: Ok(user.Id);
	}

	/// <summary>
	/// Sign out
	/// </summary>
	/// <param name="userManager">Automatically fetch from container</param>
	/// <param name="cancellationToken">Cancellation Token</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpPost("signout")]
	[ApiSecurity]
	public async Task<IActionResult> SignOut(
		[FromServices] UserManager<User> userManager,
		CancellationToken cancellationToken)
	{
		var username = User.Identity.Name;
		var user = userManager.Users.SingleOrDefault(u => u.UserName == username);

		await userManager.UpdateSecurityStampAsync(user);

		return Ok();
	}

	/// <summary>
	/// Refresh token
	/// </summary>
	/// <param name="userManager">Automatically fetch from container</param>
	/// <param name="jwtSettings">Automatically fetch from container</param>
	/// <param name="localAuthService">Automatically fetch from container</param>
	/// <param name="refreshTokenDto">Refresh token dto</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[AllowAnonymous]
	[HttpPost("refresh")]
	public async Task<IActionResult> RefreshToken(
		[FromServices] UserManager<User> userManager,
		[FromServices] IOptionsSnapshot<JwtSettings> jwtSettings,
		[FromServices] ILocalAuthService localAuthService,
		RefreshTokenDto refreshTokenDto)
	{
		var principal = localAuthService.GetPrincipalFromExpiredToken(refreshTokenDto.AccessToken, jwtSettings.Value);

		var user = userManager.Users.SingleOrDefault(u => u.UserName == principal.Identity.Name);

		if (user == null)
		{
			return Unauthorized("Invalid token");
		}

		var refreshToken = await userManager
			.GetAuthenticationTokenAsync(user, jwtSettings.Value.LoginProvider, jwtSettings.Value.RefreshTokenTitle);

		if (refreshTokenDto.RefreshToken != refreshToken)
		{
			return Unauthorized("Invalid token");
		}

		var isRefreshTokenValid = await userManager
			.VerifyUserTokenAsync(user, jwtSettings.Value.LoginProvider, jwtSettings.Value.RefreshTokenTitle, refreshToken);

		if (isRefreshTokenValid == false)
		{
			return Unauthorized("Invalid token");
		}

		var tokens = await localAuthService.GenerateTokens(user, jwtSettings.Value);

		return Ok(tokens);
	}

	/// <summary>
	/// Seed identity data (TODO: In production this will run automatically)
	/// </summary>
	/// <param name="userSeedService">Automatically fetch from container</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[AllowAnonymous]
	[HttpPost("seed")]
	public async Task<IActionResult> SeedIdentityData(
		[FromServices] IUserSeedService userSeedService)
	{
		await userSeedService.Initialize();

		return Ok();
	}


	/// <summary>
	/// update
	/// </summary>
	/// <param name="userInformationService">User Get Service</param>
	/// <param name="userRegisterDto">User Regidter dto</param>
	/// <param name="id">User id</param>
	/// <param name="cancellationToken">Cancellation Token</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	//[ProducesResponseType((int)HttpStatusCode.NotFound)]
	//[ProducesResponseType((int)HttpStatusCode.OK)]
	//[ProducesResponseType((int)HttpStatusCode.BadRequest)]
	//[HttpPost("Update")]
	//[AllowAnonymous]
	//public async Task<IActionResult> Update(
	//	[FromServices] IUserInformationService userInformationService,
	//	UserRegisterDto userRegisterDto,
	//	int id,
	//	CancellationToken cancellationToken)
}
