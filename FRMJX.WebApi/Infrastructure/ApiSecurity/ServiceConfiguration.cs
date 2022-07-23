namespace FRMJX.WebApi.Infrastructure.ApiSecurity;

using FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

internal static class ServiceConfiguration
{
	internal static void ConfigureClaimManagementServiceIoCServices(this IServiceCollection services)
	{
		services.AddScoped<ILocalApiSecuritySecurityService, LocalApiSecuritySecurityService>();
		services.AddScoped<ILocalApiSecurityClaimUtilityService, LocalApiSecurityClaimUtilityService>();
		services.AddSingleton<ILocalApiSecurityClaimManagementService, LocalApiSecurityClaimManagementService>();
	}
}
