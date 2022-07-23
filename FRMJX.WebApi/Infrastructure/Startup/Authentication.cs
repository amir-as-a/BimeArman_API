namespace FRMJX.WebApi.Infrastructure.Startup;

using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Infrastructure;
using FRMJX.WebApi.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

internal static class Authentication
{
	internal static void ConfigureXAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
	{
		var jwtSettings = configuration
			.GetSection(nameof(JwtSettings))
			.Get<JwtSettings>();

		services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromSeconds(jwtSettings.RefreshTokenExpirationInSeconds));

		services
			.AddIdentity<User, Role>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				options.SignIn.RequireConfirmedEmail = false;
				options.SignIn.RequireConfirmedPhoneNumber = false;

				options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = true;

				options.Tokens.PasswordResetTokenProvider = jwtSettings.LoginProvider;
			})
			.AddTokenProvider<DataProtectorTokenProvider<User>>(jwtSettings.LoginProvider)
			.AddEntityFrameworkStores<DatabaseContext>();

		services
			.AddAuthorization()
			.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					RequireSignedTokens = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
					TokenDecryptionKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.EncryptionKey)),

					// Validate the JWT Issuer (iss) claim
					ValidateIssuer = true,
					ValidIssuer = jwtSettings.Issuer,

					// Validate the JWT Audience (aud) claim
					ValidateAudience = true,
					ValidAudience = jwtSettings.Issuer,

					// Validate the token expiry
					ValidateLifetime = true,

					// If you want to allow a certain amount of clock drift, set that here
					ClockSkew = TimeSpan.Zero,
				};
			});
	}

	internal static void UseXAuthentication(this IApplicationBuilder app)
	{
		app.UseAuthentication();

		app.UseAuthorization();
	}
}
