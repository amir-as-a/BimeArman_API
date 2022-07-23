namespace FRMJX.WebApi.Infrastructure.Services;

using FRMJX.WebApi.Infrastructure.ApiSecurity;
using FRMJX.WebApi.Infrastructure.Services.Abstraction;
using FRMJX.WebApi.Infrastructure.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

internal static class ServiceConfiguration
{
	internal static void ConfigureLocalServiceIoCServices(this IServiceCollection services)
	{
		services.ConfigureClaimManagementServiceIoCServices();

		services.AddScoped<ILocalAuthService, LocalAuthService>();
		services.AddScoped<ILocalUserService, LocalUserService>();
	}
}
