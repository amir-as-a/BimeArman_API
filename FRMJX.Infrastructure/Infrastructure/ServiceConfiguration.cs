namespace FRMJX.Infrastructure.Infrastructure;

using FRMJX.Infrastructure.Infrastructure.SharedServices;
using Gelf.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

public static class ServiceConfiguration
{
	public static void ConfigureInfrastructureSharedServices(this IServiceCollection services, IConfiguration configuration)
	{
		services
		.Configure<GelfLoggerOptions>(configuration.GetSection("SystemLogger"))
		.AddLogging(config => config
			.AddConfiguration(configuration.GetSection("Logging"))
			.AddGelf(options =>
			{
				options.AdditionalFields["machine_name"] = Environment.MachineName;

				var assemblyInformationalVersionAttribute = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
				if (assemblyInformationalVersionAttribute is not null)
				{
					options.AdditionalFields["app_version"] = assemblyInformationalVersionAttribute.InformationalVersion;
				}

				options.CompressUdp = true;
			}));

		services.AddScoped(typeof(IGridService<,>), typeof(GridService<,>));
	}
}
