namespace FRMJX.Infrastructure;

using FRMJX.Infrastructure.BasicDataDomain;
using FRMJX.Infrastructure.CmsDomain;
using FRMJX.Infrastructure.Infrastructure;
using FRMJX.Infrastructure.SecurityDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceConfiguration
{
	public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<DatabaseContext>(
			optionsAction:
			options => options
				.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					sqlServerOptionAction => sqlServerOptionAction
						.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)
						.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)),
			contextLifetime: ServiceLifetime.Scoped,
			optionsLifetime: ServiceLifetime.Scoped);

		services.ConfigureBasicDataDomainServices();
		services.ConfigureCmsDomainServices();
		services.ConfigureSecurityDomainServices();
		services.ConfigureInfrastructureSharedServices(configuration);
	}
}
