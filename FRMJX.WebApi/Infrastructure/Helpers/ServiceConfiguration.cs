namespace FRMJX.WebApi.Infrastructure.Helpers;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class ServiceConfiguration
{
	internal static void ConfigureHelperIoCServices(this IServiceCollection services, IConfiguration configuration) =>
		services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
}
