namespace FRMJX.WebApi.Infrastructure.Startup;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecking
{
	internal static void ConfigureHealthCheckServices(this IServiceCollection services) =>
		services.AddHealthChecks();

	internal static void ConfigureHealthCheck(this IApplicationBuilder app) =>
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapHealthChecks("/health",
				new HealthCheckOptions()
				{
					AllowCachingResponses = false,
				});

			endpoints.MapControllers();
		});
}
